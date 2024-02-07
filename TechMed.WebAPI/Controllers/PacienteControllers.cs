using Microsoft.AspNetCore.Mvc;
using TechMed.Infrastructure.Persistence.Configurations;
using TechMed.Domain.Entities;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class PacienteControllers : ControllerBase
{
   private readonly IPacienteService _pacienteService;
   public List<PacienteViewModel> Pacientes => _pacienteService.GetAll();
   public PacienteControllers(IPacienteService service) => _pacienteService = service;
   [HttpGet("pacientes")]
   public IActionResult Get()
   {
      return Ok(Pacientes);

   }

   [HttpPost("pacientes")]
   public IActionResult Post([FromBody] NewPacienteInputModel paciente)
   {
      _pacienteService.Create(paciente);
      return CreatedAtAction(nameof(Get), paciente);
 
   }


}
