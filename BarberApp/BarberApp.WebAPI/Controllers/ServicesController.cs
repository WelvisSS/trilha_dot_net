using Microsoft.AspNetCore.Mvc;
using BarberApp.Domain.Entities;
using BarberApp.Domain.Interfaces;
using IServiceCollection = BarberApp.Domain.Interfaces.IServiceCollection;

namespace BarberApp.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ServiceController : ControllerBase
{
    private readonly IServiceCollection _services;
    public List<Service> Services => _services.GetAll().ToList();
    public ServiceController(IDatabaseFake dbFake) => _services = dbFake.ServicesCollection;


[HttpGet("service")]
   public IActionResult GetAll()
   {
      return Ok(Services);
   }


  [HttpGet("service/{id}")]
   public IActionResult GetById(int id)
   {
      var service = _services.GetById(id);
      return Ok(service);
   }

   [HttpPost("service")]
   public IActionResult Post([FromBody] Service service)
   {
      _services.Create(service);
      return CreatedAtAction(nameof(GetAll), service);
 
   }

   [HttpPut("service/{id}")]
   public IActionResult Put(int id, [FromBody] Service service)
   {
      if (_services.GetById(id) == null)
         return NoContent();
      _services.Update(id, service);
      return Ok(_services.GetById(id));
   }

   [HttpDelete("service/{id}")]
   public IActionResult Delete(int id)
   {
      if (_services.GetById(id) == null)
         return NoContent();
      _services.Delete(id);
      return Ok();
   }

}
