using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.Services.Interfaces;
using ResTIConnect.Aplication.ViewModels;
using ResTIConnect.Aplication;


namespace ResTIConnect.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class EventoController : ControllerBase
{
    private readonly IEventoService _eventoService;
    public List<EventoViewModel> Eventos => _eventoService.GetAll().ToList();
    public EventoController(IEventoService service) => _eventoService = service;

    [HttpGet("eventos")]
    public IActionResult Get()
    {
        return Ok(Eventos);
    }

    [HttpGet("Eventos/{id}")]
    public IActionResult GetById(int id)
    {
        var evento = _eventoService.GetById(id);
        if (evento is null)
            return NoContent();
        return Ok(evento);
    }

    [HttpPost("evento")]
    public IActionResult Post([FromBody] NewEventoInputModel evento)
    {
        _eventoService.Create(evento);
        return CreatedAtAction(nameof(Get), evento);

    }

    [HttpPut("evento/{id}")]
    public IActionResult Put(int id, [FromBody] NewEventoInputModel evento)
    {
        if (_eventoService.GetById(id) == null)
            return NoContent();
        _eventoService.Update(id, evento);
        return Ok(_eventoService.GetById(id));
    }

    [HttpDelete("evento/{id}")]
    public IActionResult Delete(int id)
    {
        if (_eventoService.GetById(id) == null)
            return NoContent();
        _eventoService.Delete(id);
        return Ok();
    }
}
