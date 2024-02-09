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

   [HttpGet("medico/{id}/atendimento")]
   public List<AtendimentoViewModel> GetConsultationsAndExamsByDoctorId(int id)
   {
      var atendimentos = _atendimentoService.GetConsultationsAndExamsByDoctorId(id);
      return atendimentos;
   }

   [HttpGet("paciente/{id}/atendimentos")]
   public List<AtendimentoViewModel> GetConsultationsAndExamsByPatientId(int id)
   {
      var atendimentos = _atendimentoService.GetConsultationsAndExamsByPatientId(id);
      return atendimentos;
   }

   [HttpGet("atendimentos/porPeriodo/{inicio}/{fim}")]
   public List<AtendimentoViewModel> GetConsultationsAndExamsByDates(string inicio, string fim)
   {
      var atendimentos = _atendimentoService.GetConsultationsAndExamsByDates(inicio, fim);
      return atendimentos;
   }


   [HttpPost("atendimento")]
   public IActionResult Post([FromBody] NewAtendimentoInputModel atendimento)
   {
      _atendimentoService.Create(atendimento);
      return CreatedAtAction(nameof(Get), atendimento);

   }

   [HttpPut("update/{id}")]
   public IActionResult Put(int id, [FromBody] NewAtendimentoInputModel atendimento)
   {
      if (_atendimentoService.GetById(id) == null)
         return NoContent();
      _atendimentoService.Update(id, atendimento);
      return Ok(_atendimentoService.GetById(id));
   }

   [HttpDelete("delete/{id}")]
   public IActionResult Delete(int id)
   {
      _atendimentoService.Delete(id);
      return Ok("Atendimento deletado com sucesso!");
   }

}
