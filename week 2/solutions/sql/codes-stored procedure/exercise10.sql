CREATE PROCEDURE sp_FilterEmployees
    @FilterColumn NVARCHAR(50),
    @FilterValue NVARCHAR(100)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = 'SELECT * FROM Employees WHERE ' + QUOTENAME(@FilterColumn) + ' = @value';

    EXEC sp_executesql @sql, N'@value NVARCHAR(100)', @value = @FilterValue;
END;
GO

EXEC sp_FilterEmployees 'DepartmentID', '2';
GO
