using Microsoft.AspNetCore.Mvc;
using BarberApp.Domain.Entities;
using BarberApp.Domain.Interfaces;

namespace BarberApp.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeCollection _employees;
    public List<Employee> Employees => _employees.GetAll().ToList();
    public EmployeeController(IDatabaseFake dbFake) => _employees = dbFake.EmployeesCollection;


[HttpGet("employee")]
   public IActionResult GetAll()
   {
      return Ok(Employees);
   }


  [HttpGet("employee/{id}")]
   public IActionResult GetById(int id)
   {
      var employee = _employees.GetById(id);
      return Ok(employee);
   }

   [HttpPost("employee")]
   public IActionResult Post([FromBody] Employee employee)
   {
      _employees.Create(employee);
      return CreatedAtAction(nameof(GetAll), employee);
 
   }

   [HttpPut("employee/{id}")]
   public IActionResult Put(int id, [FromBody] Employee employee)
   {
      if (_employees.GetById(id) == null)
         return NoContent();
      _employees.Update(id, employee);
      return Ok(_employees.GetById(id));
   }

   [HttpDelete("employee/{id}")]
   public IActionResult Delete(int id)
   {
      if (_employees.GetById(id) == null)
         return NoContent();
      _employees.Delete(id);
      return Ok();
   }

}