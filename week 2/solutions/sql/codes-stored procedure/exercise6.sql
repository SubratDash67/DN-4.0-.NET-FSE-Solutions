CREATE PROCEDURE sp_TotalSalaryByDepartment
    @DepartmentID INT,
    @TotalSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SELECT @TotalSalary = SUM(Salary)
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

DECLARE @salarySum DECIMAL(10,2);
EXEC sp_TotalSalaryByDepartment 1, @TotalSalary = @salarySum OUTPUT;
SELECT @salarySum AS TotalSalary;
GO
