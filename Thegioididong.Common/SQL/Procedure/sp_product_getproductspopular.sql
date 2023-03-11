SELECT TOP 10
    pv.Id,
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
    SUM(od.Quantity) AS TotalQuantitySold,
    r.StarRating,
    r.ReviewCount
FROM ProductVariants AS pv
JOIN Products AS p ON pv.ProductId = p.Id
JOIN SalesOrderDetails AS od ON pv.Id = od.ProductVariantId
JOIN SalesOrders AS o ON od.SalesOrderId = o.Id
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
WHERE o.OrderStatus = 1
AND o.CreateAt >= DATEADD(month, -1, GETDATE())
AND pv.Published = 1
AND p.Published = 1
GROUP BY pv.Id, p.IsInterest, p.Image, pv.Name, p.BadgeProductId, pvp.OriginalPrice, pvd.DiscountedPrice, pvd.DiscountPercent, r.StarRating, r.ReviewCount
ORDER BY TotalQuantitySold DESC
