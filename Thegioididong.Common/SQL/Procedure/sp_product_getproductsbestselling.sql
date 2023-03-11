SELECT TOP 10 pv.Id, 
       p.IsInterest, 
       p.Image, 
       pv.Name, 
       JSON_QUERY(
           (
               SELECT bp.Id AS Id, 
                      bp.Name AS Name, 
                      bp.Image AS Image, 
                      bp.BackgroundColor AS BackgroundColor
               FROM BadgeProducts AS bp
               WHERE bp.Id = p.BadgeProductId
               FOR JSON PATH, INCLUDE_NULL_VALUES
           ), 
           '$[0]'
       ) AS BadgeProduct, 
       pvp.OriginalPrice,
       FORMAT(ISNULL(ROUND(pvd.DiscountedPrice, -4), pvp.OriginalPrice), '###0') AS DiscountedPrice,
       ISNULL(pvd.DiscountPercent, 0) AS DiscountPercent,
       ISNULL(pvp.OriginalPrice - pvd.DiscountedPrice, 0) AS AmountSaved,
       r.StarRating,
       r.ReviewCount
FROM (
    SELECT ROW_NUMBER() OVER (PARTITION BY ProductId ORDER BY DisplayOrder DESC) AS RowNumber, 
           Id, 
           ProductId, 
           Name, 
           UnitId, 
           DisplayOrder, 
           Published, 
           CreatedAt, 
           UpdateAt
    FROM ProductVariants
) AS pv 
JOIN Products AS p ON pv.ProductId = p.Id
OUTER APPLY (
    SELECT TOP 1 Price AS OriginalPrice
    FROM ProductVariantPrices
    WHERE ProductVariantId = pv.Id AND StartDate <= GETDATE() AND (EndDate IS NULL OR EndDate >= GETDATE())
    ORDER BY StartDate DESC
) AS pvp
OUTER APPLY (
    SELECT TOP 1 
           DiscountPercent, 
           OriginalPrice - OriginalPrice * DiscountPercent / 100 AS DiscountedPrice
    FROM ProductVariantDiscountPrice
    WHERE ProductVariantId = pv.Id AND StartDate <= GETDATE() AND (EndDate IS NULL OR EndDate >= GETDATE()) AND Status = 1
    ORDER BY StartDate DESC
) AS pvd
OUTER APPLY (
    SELECT 
           AVG(Rating) AS StarRating,
           COUNT(*) AS ReviewCount
    FROM Ratings
    WHERE ProductId = p.Id AND Rating IS NOT NULL
) AS r
WHERE pv.RowNumber = 1
AND pv.Published = 1 AND p.Published = 1
ORDER BY AmountSaved DESC
