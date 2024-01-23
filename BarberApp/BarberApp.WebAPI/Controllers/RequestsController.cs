﻿using Microsoft.AspNetCore.Mvc;
using BarberApp.Domain.Entities;
using BarberApp.Domain.Interfaces;
namespace BarberApp.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class RequestsController : ControllerBase
{
    private readonly IRequestCollection _requests;
    public List<Request> Request => _requests.GetAll().ToList();
    public RequestsController(IDatabaseFake dbFake) => _requests = dbFake.RequestsCollection;

    // [HttpGet("medicos")]
    // public IActionResult Get()
    // {
    //     return Ok(Medicos);
    // }

    // [HttpGet("medico/{id}")]
    // public IActionResult GetById(int id)
    // {
    //     var medico = _medicos.GetById(id);
    //     return Ok(medico);
    // }

    // [HttpPost("medico")]
    // public IActionResult Post([FromBody] Medico medico)
    // {
    //     _medicos.Create(medico);
    //     return CreatedAtAction(nameof(Get), medico);

    // }

    // [HttpPut("medico/{id}")]
    // public IActionResult Put(int id, [FromBody] Medico medico)
    // {
    //     if (_medicos.GetById(id) == null)
    //         return NoContent();
    //     _medicos.Update(id, medico);
    //     return Ok(_medicos.GetById(id));
    // }

    // [HttpDelete("medico/{id}")]
    // public IActionResult Delete(int id)
    // {
    //     if (_medicos.GetById(id) == null)
    //         return NoContent();
    //     _medicos.Delete(id);
    //     return Ok();
    // }

    // [HttpGet("medico/{id}/atendimentos")]
    // public IActionResult GetAtendimentos(int id)
    // {
    //    var atendimento = Enumerable.Range(1, 5).Select(index => new Atendimento
    //      {
    //          AtendimentoId = index,
    //          DataHora = DateTime.Now,
    //          MedicoId = id,
    //          Medico = new Medico
    //          {
    //              MedicoId = id,
    //              Nome = $"Medico {id}"
    //          }
    //      })
    //      .ToArray();
    //    return Ok(atendimento);
    // }
}
