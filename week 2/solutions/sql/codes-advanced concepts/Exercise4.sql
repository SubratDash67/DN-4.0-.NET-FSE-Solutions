
SELECT
    p.ProductName,
    FORMAT(o.OrderDate, 'yyyy-MM') AS OrderMonth,
    SUM(od.Quantity) AS TotalQuantity
INTO ProductSalesByMonth
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.ProductName, FORMAT(o.OrderDate, 'yyyy-MM');
GO

SELECT *
FROM ProductSalesByMonth
PIVOT (
    SUM(TotalQuantity)
    FOR OrderMonth IN ([2023-01], [2023-02], [2023-03], [2023-04])
) AS PivotedSales;
GO

SELECT ProductName, OrderMonth, TotalQuantity
FROM (
    SELECT *
    FROM ProductSalesByMonth
    PIVOT (
        SUM(TotalQuantity)
        FOR OrderMonth IN ([2023-01], [2023-02], [2023-03], [2023-04])
    ) AS Pivoted
) AS p
UNPIVOT (
    TotalQuantity FOR OrderMonth IN ([2023-01], [2023-02], [2023-03], [2023-04])
) AS Unpivoted;
GO
