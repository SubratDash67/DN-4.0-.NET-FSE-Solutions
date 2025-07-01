INSERT INTO Orders (OrderID, CustomerID, OrderDate) VALUES
(5, 1, '2023-05-01'),
(6, 1, '2023-05-15'),
(7, 1, '2023-06-01');
GO

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
(5, 5, 1, 1),
(6, 6, 2, 1),
(7, 7, 4, 1);
GO

WITH CustomerOrderCounts AS (
    SELECT
        CustomerID,
        COUNT(*) AS OrderCount
    FROM Orders
    GROUP BY CustomerID
)

SELECT c.CustomerID, c.Name, c.Region, o.OrderCount
FROM CustomerOrderCounts o
JOIN Customers c ON c.CustomerID = o.CustomerID
WHERE o.OrderCount > 3;
GO
