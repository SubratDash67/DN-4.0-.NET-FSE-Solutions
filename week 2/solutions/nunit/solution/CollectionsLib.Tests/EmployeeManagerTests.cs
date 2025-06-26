using NUnit.Framework;
using CollectionsLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsLib.Tests
{
  [TestFixture]
  public class EmployeeManagerTests
  {
    private EmployeeManager manager = null!;

    [SetUp]
    public void Setup()
    {
      manager = new EmployeeManager();
    }

    [TearDown]
    public void Teardown()
    {
      manager = null!;
    }

    [Test]
    public void GetEmployees_NoEmployeeIsNull_ReturnsValidList()
    {
      var employees = manager.GetEmployees();
      Assert.That(employees, Has.All.Not.Null);

    }

    [Test]
    public void GetEmployees_ContainsEmpId100_ReturnsTrue()
    {
      var employees = manager.GetEmployees();
      Assert.That(employees.Any(e => e.EmpId == 100), Is.True);
    }

    [Test]
    public void GetEmployees_UniqueEmployeeList_ReturnsTrue()
    {
      var employees = manager.GetEmployees();
      var distinct = employees.Distinct().ToList();
      Assert.That(distinct.Count, Is.EqualTo(employees.Count));
    }

    [Test]
    public void GetEmployeesAndPreviousJoinees_HaveSameItems_ReturnsTrue()
    {
      var all = manager.GetEmployees();
      var previous = manager.GetEmployeesWhoJoinedInPreviousYears();


      Assert.That(previous, Is.EquivalentTo(all));
    }
  }
}
