ALTER PROCEDURE [dbo].[sp_productcategory_getproductcategorynavigation]
AS
    BEGIN

		
		
		SELECT 
			(
				SELECT TOP 10 PC.Id AS Id, PC.Name AS Name, PC.BadgeIcon As BadgeIcon,
		(	SELECT TOP 3 PG1.Id AS Id, PG1.Name AS Name,
			(	SELECT TOP 10 PC2.Id AS Id, PC2.Name AS Name FROM ProductCategories AS PC2
				WHERE PC2.ProductCategoryGroupId = PG1.Id AND PC2.Published = 1
				ORDER BY PC2.DisplayOrder DESC
				FOR JSON PATH
			) AS ProductCategories
			FROM ProductCategoryGroups AS PG1
			WHERE PG1.ProductCategoryId = PC.Id AND PG1.Published = 1
			ORDER BY PG1.DisplayOrder DESC
			FOR JSON PATH
		) AS ProductCategoryGroups,
		(	SELECT TOP 10 PC1.Id AS Id, PC1.Name AS Name FROM ProductCategories AS PC1
			WHERE PC1.ParentProductCategoryId = PC.Id AND PC1.Published = 1
			ORDER BY PC1.DisplayOrder DESC
			FOR JSON PATH
		) AS ProductCategoryChilds
		FROM ProductCategories AS PC
		WHERE PC.Published = 1 AND PC.ParentProductCategoryId IS NULL AND PC.ProductCategoryGroupId IS NULL
		ORDER BY PC.DisplayOrder DESC
		FOR JSON PATH
			) AS Items ,
		1 AS TotalPages,
		0 AS PageIndex,0 AS PageSize, 
		10 AS TotalRecords

END;