using FirstWebApi.Filters;
using FirstWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers;

[ApiController]
[Route("api/emp")]
[Authorize(Roles = "Admin,POC")]
public class EmployeeController : ControllerBase
public class EmployeeController : ControllerBase
{
  private static List<Employee> employees = GetStandardEmployeeList();

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public ActionResult<List<Employee>> GetEmployees()
  {
    throw new Exception("This is a demo exception");

  }

  [HttpGet("standard")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public ActionResult<Employee> GetStandard() => Ok(employees[0]);

  [HttpPost]
  public IActionResult PostEmployee([FromBody] Employee emp)
  {
    employees.Add(emp);
    return Ok(employees);
  }

  [HttpPut("{id}")]
  public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee emp)
  {
    if (id <= 0)
      return BadRequest("Invalid employee id");

    var existing = employees.FirstOrDefault(e => e.Id == id);
    if (existing == null)
      return BadRequest("Invalid employee id");

    existing.Name = emp.Name;
    existing.Salary = emp.Salary;
    existing.Permanent = emp.Permanent;
    existing.Department = emp.Department;
    existing.Skills = emp.Skills;
    existing.DateOfBirth = emp.DateOfBirth;

    return Ok(existing);
  }
  [HttpDelete("{id}")]
  public IActionResult DeleteEmployee(int id)
  {
    if (id <= 0)
      return BadRequest("Invalid employee id");

    var emp = employees.FirstOrDefault(e => e.Id == id);
    if (emp == null)
      return BadRequest("Invalid employee id");

    employees.Remove(emp);
    return Ok($"Employee with ID {id} deleted.");
  }


  private static List<Employee> GetStandardEmployeeList()
  {
    return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John Doe",
                Salary = 50000,
                Permanent = true,
                Department = new Department { Id = 101, Name = "HR" },
                Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" }, new Skill { Id = 2, Name = "SQL" } },
                DateOfBirth = new DateTime(1990, 1, 1)
            }
        };
  }
}
