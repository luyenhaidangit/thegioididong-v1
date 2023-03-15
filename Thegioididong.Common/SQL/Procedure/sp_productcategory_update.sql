USE [Thegioididong]
GO
/****** Object:  StoredProcedure [dbo].[sp_productcategory_update]    Script Date: 15/03/2023 8:09:52 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_productcategory_update]
(
    @request NVARCHAR(MAX)
)
AS
BEGIN
    DECLARE @ProductCategoryId INT;
    DECLARE @ParentProductCategoryId INT;
    DECLARE @ProductCategoryGroupId INT;
    DECLARE @Name NVARCHAR(80);
    DECLARE @BadgeIcon VARCHAR(800);
    DECLARE @Image VARCHAR(800);
    DECLARE @DisplayOrder INT;
    DECLARE @Published BIT;
    
    -- Lấy giá trị các trường từ request
    SELECT 
        @ProductCategoryId = JSON_VALUE(@request, '$.id'),
        @ParentProductCategoryId = JSON_VALUE(@request, '$.parentProductCategoryId'),
        @ProductCategoryGroupId = JSON_VALUE(@request, '$.productCategoryGroupId'),
        @Name = JSON_VALUE(@request, '$.name'),
        @BadgeIcon = JSON_VALUE(@request, '$.badgeIcon'),
        @Image = JSON_VALUE(@request, '$.image'),
        @DisplayOrder = JSON_VALUE(@request, '$.displayOrder'),
        @Published = JSON_VALUE(@request, '$.published');
    
    -- Cập nhật thông tin danh mục sản phẩm có ID tương ứng
    UPDATE ProductCategories 
    SET 
        ParentProductCategoryId = @ParentProductCategoryId,
        ProductCategoryGroupId = @ProductCategoryGroupId,
        Name = @Name,
        BadgeIcon = @BadgeIcon,
        Image = @Image,
        DisplayOrder = @DisplayOrder,
        Published = @Published
    WHERE Id = @ProductCategoryId;

END;
