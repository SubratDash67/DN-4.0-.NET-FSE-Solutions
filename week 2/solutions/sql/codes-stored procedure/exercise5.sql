CREATE PROCEDURE sp_CountEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS EmployeeCount
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

EXEC sp_CountEmployeesByDepartment 1;
GO
