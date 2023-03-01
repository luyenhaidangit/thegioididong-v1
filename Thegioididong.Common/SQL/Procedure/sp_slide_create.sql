ALTER PROCEDURE [dbo].[sp_slide_create]
(
@Name NVARCHAR(160),
@Page VARCHAR(160),
@Position VARCHAR(160),
@Published BIT,
@SlideItems NVARCHAR(MAX)
)
AS
    BEGIN
	INSERT INTO Slides(Name,Page,Position,Published) VALUES (@Name, @Page, @Position, @Published);
	DECLARE @slideId INT = SCOPE_IDENTITY();
	 IF(@SlideItems IS NOT NULL)
	 BEGIN
	   INSERT INTO SlideItems
                (
				 SlideId,
				 Title,
                 Image, 
                 URL
                )
		SELECT 
				@slideId,	
				JSON_VALUE(si.value, '$.title'), 
				JSON_VALUE(si.value, '$.image'), 
				JSON_VALUE(si.value, '$.url')
				FROM OPENJSON(@SlideItems) AS si;
	 END;
	 END