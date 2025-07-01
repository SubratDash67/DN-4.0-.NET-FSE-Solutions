DROP TABLE IF EXISTS StagingProducts;
GO
CREATE TABLE StagingProducts (
    ProductID INT,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);
GO
TRUNCATE TABLE StagingProducts;
GO

INSERT INTO StagingProducts (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1100.00),
(2, 'Smartphone', 'Electronics', 850.00),
(5, 'Smartwatch', 'Electronics', 300.00); 
GO
MERGE Products AS Target
USING (
    SELECT ProductID, ProductName, Category, Price
    FROM StagingProducts
    GROUP BY ProductID, ProductName, Category, Price
) AS Source
ON Target.ProductID = Source.ProductID
WHEN MATCHED THEN
    UPDATE SET Target.ProductName = Source.ProductName,
               Target.Category = Source.Category,
               Target.Price = Source.Price
WHEN NOT MATCHED THEN
    INSERT (ProductID, ProductName, Category, Price)
    VALUES (Source.ProductID, Source.ProductName, Source.Category, Source.Price);
GO
