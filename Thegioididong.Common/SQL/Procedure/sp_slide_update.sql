USE [Thegioididong]
GO
/****** Object:  StoredProcedure [dbo].[sp_slide_update]    Script Date: 01/03/2023 4:11:23 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_slide_update]
(
    @request NVARCHAR(MAX)
)
AS
BEGIN
    DECLARE @Id INT;
    DECLARE @Name NVARCHAR(160);
    DECLARE @Page VARCHAR(160);
    DECLARE @Position VARCHAR(160);
    DECLARE @Published BIT;
    
    
    -- Lấy giá trị các trường từ request
SELECT 
    @Id = JSON_VALUE(@request, '$.id'),
    @Name = JSON_VALUE(@request, '$.name'),
    @Page = JSON_VALUE(@request, '$.page'),
    @Position = JSON_VALUE(@request, '$.position'),
    @Published = JSON_VALUE(@request, '$.published');

-- Cập nhật thông tin của Slide
UPDATE Slides 
SET 
    Name = IIF(@Name IS NULL, Name, @Name),
    Page = IIF(@Page IS NULL, Page, @Page),
    Position = IIF(@Position IS NULL, Position, @Position),
    Published = IIF(@Published IS NULL, Published, @Published)
WHERE Id = @Id;

-- Xóa các SlideItem không còn tồn tại trong request
DELETE FROM SlideItems 
WHERE 
    SlideId = @Id 
    AND 
    Id IN (
        SELECT si.Id 
        FROM SlideItems si
        LEFT JOIN OPENJSON(@request, '$.slideItems') WITH (Id INT '$.id') r ON si.Id = r.Id
        WHERE r.Id IS NULL
    );

-- Cập nhật hoặc thêm mới SlideItem
IF (@request IS NOT NULL)
BEGIN
    UPDATE SlideItems
    SET
        Title = JSON_VALUE(si.value, '$.title'),
        Image = JSON_VALUE(si.value, '$.image'),
        URL = JSON_VALUE(si.value, '$.url')
    FROM OPENJSON(@request, '$.slideItems') AS si
    WHERE 
        SlideItems.Id = JSON_VALUE(si.value, '$.id')
        AND
        JSON_VALUE(si.value, '$.id') IS NOT NULL
        AND
        SlideItems.SlideId = @Id;

    INSERT INTO SlideItems (SlideId, Title, Image, URL)
    SELECT 
        @Id,
        JSON_VALUE(si.value, '$.title'),
        JSON_VALUE(si.value, '$.image'),
        JSON_VALUE(si.value, '$.url')
    FROM OPENJSON(@request, '$.slideItems') AS si
    WHERE JSON_VALUE(si.value, '$.id') IS NULL;
END;

END;
