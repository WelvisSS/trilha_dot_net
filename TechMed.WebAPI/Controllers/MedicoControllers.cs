using Microsoft.AspNetCore.Mvc;
using TechMed.Infrastructure.Persistence.Configurations;
using TechMed.Domain.Entities;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class MedicoControllers : ControllerBase
{
   private readonly IMedicoService _medicoService;
   public List<MedicoViewModel> Medicos => _medicoService.GetAll();
   public MedicoControllers(IMedicoService service) => _medicoService = service;
   [HttpGet("medicos")]
   public IActionResult Get()
   {
      return Ok(Medicos);

   }

   [HttpPost("medicos")]
   public IActionResult Post([FromBody] NewMedicoInputModel medico)
   {
      _medicoService.Create(medico);
      return CreatedAtAction(nameof(Get), medico);
 
   }


}
