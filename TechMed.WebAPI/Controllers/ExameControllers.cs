using Microsoft.AspNetCore.Mvc;
using TechMed.Infrastructure.Persistence.Configurations;
using TechMed.Domain.Entities;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ExameControllers : ControllerBase
{
   private readonly IExameService _exameService;
   public List<ExameViewModel> Exame => _exameService.GetAll();
   public ExameControllers(IExameService service) => _exameService = service;
   [HttpGet("exames")]
   public IActionResult Get()
   {
      return Ok(Exame);

   }

   [HttpPost("exames")]
   public IActionResult Post([FromBody] NewExameInputModel exame)
   {
      _exameService.Create(exame);
      return CreatedAtAction(nameof(Get), exame);
 
   }


}
