using Microsoft.AspNetCore.Mvc;
using TechMed.Infrastructure.Persistence.Configurations;
using TechMed.Domain.Entities;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class AtendimentoControllers : ControllerBase
{
   private readonly IAtendimentoService _atendimentoService;
   public List<AtendimentoViewModel> Atendimentos => _atendimentoService.GetAll();
   public AtendimentoControllers(IAtendimentoService service) => _atendimentoService = service;
   [HttpGet("atendimentos")]
   public IActionResult Get()
   {
      return Ok(Atendimentos);

   }

   [HttpPost("atendimento")]
   public IActionResult Post([FromBody] NewAtendimentoInputModel atendimento)
   {
      _atendimentoService.Create(atendimento);
      return CreatedAtAction(nameof(Get), atendimento);
 
   }

   [HttpPut]
   public IActionResult Put(int id, [FromBody] NewAtendimentoInputModel atendimento)
   {
      if (_atendimentoService.GetById(id) == null)
         return NoContent();
      _atendimentoService.Update(id, atendimento);
      return Ok(_atendimentoService.GetById(id)); 
   }

   [HttpDelete]
   public IActionResult Delete([FromBody] AtendimentoViewModel atendimento)
   {
      _atendimentoService.Delete(atendimento.AtendimentoId);
      return Ok(atendimento);
   }

}
