using Microsoft.AspNetCore.Mvc;
using BarberApp.Application.Services.Interfaces;
using BarberApp.Application.ViewModels;
using BarberApp.Application.InputModels;
using Microsoft.AspNetCore.Authorization;

namespace TechMed.WebAPI.Controllers;


[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class EmployeeControllers : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public List<EmployeeViewModel> Employees => _employeeService.GetAll();
    public EmployeeControllers(IEmployeeService service) => _employeeService = service;


    [HttpGet("employees")]
    public IActionResult Get()
    {
        return Ok(Employees);

    }

    [HttpGet("employees/{id}")]
    public IActionResult Get(int id)
    {
        EmployeeViewModel? employee = _employeeService.GetById(id);

        if (employee is null)
        {
            return NoContent();
        }
        return Ok(employee);
    }

    //Implementar apos criação do service
    // [HttpGet("client/{id}/employees")]
    // public IActionResult GetByClientId(int id)
    // {
    //     List<EmployeeViewModel> employees = _employeeService.GetByClientId(id);

    //     if (employees is null)
    //     {
    //         return NoContent();
    //     }
    //     return Ok(employees);
    // }

    [HttpPost("employees")]
    [AllowAnonymous]
    public IActionResult Post([FromBody] NewEmployeeInputModel employee)
    {
        _employeeService.Create(employee);
        return CreatedAtAction(nameof(Get), employee);

    }

    [HttpPut("employees/{id}")]
    public IActionResult Put(int id, [FromBody] NewEmployeeInputModel employee)
    {
        if (_employeeService.GetById(id) == null)
            return NoContent();

        _employeeService.Update(id, employee);
        return Ok(employee);
    }

    [HttpDelete("employees/{id}")]
    public IActionResult Delete(int id)
    {
        _employeeService.Delete(id);
        return Ok();
    }


}
