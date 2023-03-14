ALTER PROCEDURE [dbo].[sp_productcategory_getproductcategoriesmanage]
(
    @request NVARCHAR(MAX)
)
AS
BEGIN
    DECLARE @PageIndex INT;
    DECLARE @PageSize INT;
    DECLARE @TotalRecords INT;
    DECLARE @TotalPages FLOAT;

    SELECT @PageIndex = JSON_VALUE(@request, '$.pageIndex');
    SELECT @PageSize = JSON_VALUE(@request, '$.pageSize');
    DECLARE @ParentProductCategoryId INT = JSON_VALUE(@request, '$.parentProductCategoryId');
    DECLARE @ProductCategoryGroupId INT = JSON_VALUE(@request, '$.productCategoryGroupId');
    DECLARE @Name NVARCHAR(MAX) = JSON_VALUE(@request, '$.name');
    DECLARE @SortBy NVARCHAR(MAX) = JSON_VALUE(@request, '$.sortBy');
    DECLARE @OrderBy NVARCHAR(MAX) = JSON_VALUE(@request, '$.orderBy');

	IF (@PageSize IS NULL OR @PageSize < 1)
		BEGIN
			SET @PageSize = -1;
	END

	IF (@PageIndex IS NULL OR @PageIndex < 1)
		BEGIN
			SET @PageIndex = 1;
	END

    IF (@PageSize > -1)
    BEGIN
        SET NOCOUNT ON;

        SELECT (ROW_NUMBER() OVER (ORDER BY
            CASE WHEN @SortBy = 'Name' AND @OrderBy = 'asc' THEN p.Name END ASC,
            CASE WHEN @SortBy = 'Name' AND @OrderBy = 'desc' THEN p.Name END DESC,
            CASE WHEN @SortBy = 'DisplayOrder' AND @OrderBy = 'asc' THEN p.DisplayOrder END ASC,
            CASE WHEN @SortBy = 'DisplayOrder' AND @OrderBy = 'desc' THEN p.DisplayOrder END DESC,
            CASE WHEN @SortBy = 'Published' AND @OrderBy = 'asc' THEN p.Published END ASC,
            CASE WHEN @SortBy = 'Published' AND @OrderBy = 'desc' THEN p.Published END DESC,
            p.Id DESC)) AS RowNumber, p.Id, p.ParentProductCategoryId, p.ProductCategoryGroupId, p.Name, 
            p.DisplayOrder, p.Published, p.BadgeIcon, p.Image
        INTO #Temp1
        FROM ProductCategories AS p
        WHERE (p.Published = 1)
            AND (@ParentProductCategoryId IS NULL OR p.ParentProductCategoryId = @ParentProductCategoryId)
            AND (@ProductCategoryGroupId IS NULL OR p.ProductCategoryGroupId = @ProductCategoryGroupId)
            AND (@Name IS NULL OR p.Name LIKE '%' + @Name + '%');

        SELECT @TotalRecords = COUNT(*) FROM #Temp1;

        SELECT @TotalPages = CEILING(CAST(@TotalRecords AS FLOAT) / @PageSize);

        SELECT @PageIndex AS PageIndex, @PageSize AS PageSize, @TotalRecords AS TotalRecords, @TotalPages AS TotalPages,
        (
            SELECT t1.Id, t1.ParentProductCategoryId, t1.ProductCategoryGroupId, t1.Name, t1.DisplayOrder, t1.Published, t1.BadgeIcon, t1.Image
            FROM #Temp1 AS t1
            WHERE RowNumber BETWEEN (@PageIndex - 1) * @PageSize + 1 AND ((@PageIndex - 1) * @PageSize + 1) + @PageSize - 1 OR @PageIndex = -1
            FOR JSON PATH
        ) AS Items;

        DROP TABLE #Temp1;
    END
    ELSE
    BEGIN
        SET NOCOUNT ON;

        SELECT (ROW_NUMBER() OVER (ORDER BY
            CASE WHEN @SortBy = 'name' AND @OrderBy = 'asc' THEN p.Name END ASC,
            CASE WHEN @SortBy = 'name' AND @OrderBy = 'desc' THEN p.Name END DESC,
            CASE WHEN @SortBy = 'displayOrder' AND @OrderBy = 'asc' THEN p.DisplayOrder END ASC,
            CASE WHEN @SortBy = 'displayOrder' AND @OrderBy = 'desc' THEN p.DisplayOrder END DESC,
            CASE WHEN @SortBy = 'published' AND @OrderBy = 'asc' THEN p.Published END ASC,
            CASE WHEN @SortBy = 'published' AND @OrderBy = 'desc' THEN p.Published END DESC,
            p.Id DESC)) AS RowNumber, p.Id, p.ParentProductCategoryId, p.ProductCategoryGroupId, p.Name, 
            p.DisplayOrder, p.Published, p.BadgeIcon, p.Image
        INTO #Temp2
		FROM ProductCategories AS p
WHERE (p.Published = 1)
AND (@ParentProductCategoryId IS NULL OR p.ParentProductCategoryId = @ParentProductCategoryId)
AND (@ProductCategoryGroupId IS NULL OR p.ProductCategoryGroupId = @ProductCategoryGroupId)
AND (@Name IS NULL OR p.Name LIKE '%' + @Name + '%');
    SELECT @TotalRecords = COUNT(*) FROM #Temp2;

    SELECT @PageIndex AS PageIndex, @PageSize AS PageSize, @TotalRecords AS TotalRecords,
    (
        SELECT t1.Id, t1.ParentProductCategoryId, t1.ProductCategoryGroupId, t1.Name, t1.DisplayOrder, t1.Published, t1.BadgeIcon, t1.Image
        FROM #Temp2 AS t1
        ORDER BY t1.Id DESC
        FOR JSON PATH
    ) AS Items;

    DROP TABLE #Temp2;
END
END
GO
