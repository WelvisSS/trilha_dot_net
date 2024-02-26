using Microsoft.AspNetCore.Mvc;
using BarberApp.Application.Services.Interfaces;
using BarberApp.Application.ViewModels;
using BarberApp.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ServiceControllers : ControllerBase
{
    private readonly IServiceService _serviceService;
    public List<ServiceViewModel> Services => _serviceService.GetAll();
    public ServiceControllers(IServiceService service) => _serviceService = service;


    [HttpGet("services")]
    public IActionResult Get()
    {
        return Ok(Services);

    }

    [HttpGet("services/{id}")]
    public IActionResult Get(int id)
    {
        ServiceViewModel? service = _serviceService.GetById(id);

        if (service is null)
        {
            return NoContent();
        }
        return Ok(service);
    }

    [HttpGet("employees/{id}/services")]
    public IActionResult GetByEmployeeId(int id)
    {
        List<ServiceViewModel> services = _serviceService.GetByEmployeeId(id);

        if (services is null)
        {
            return NoContent();
        }
        return Ok(services);
    }

    [HttpPost("services")]
    public IActionResult Post([FromBody] NewServiceInputModel service)
    {
        _serviceService.Create(service);
        return CreatedAtAction(nameof(Get), service);

    }

    [HttpPut("services/{id}")]
    public IActionResult Put(int id, [FromBody] NewServiceInputModel service)
    {
        if (_serviceService.GetById(id) == null)
            return NoContent();

        _serviceService.Update(id, service);
        return Ok(service);
    }

    [HttpDelete("services/{id}")]
    public IActionResult Delete(int id)
    {
        _serviceService.Delete(id);
        return Ok();
    }


}
