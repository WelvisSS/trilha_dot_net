using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Aplication;
using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.ViewModels;

namespace ResTIConnect.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class SistemaController : ControllerBase
{
    private readonly ISistemaService _sistemaService;
    public List<SistemaViewModel> Sistemas => _sistemaService.GetAllSistemas();
    public SistemaController(ISistemaService service) => _sistemaService = service;

    [HttpGet("Sistemas")]
    public IActionResult Get()
    {
        return Ok(Sistemas);
    }

    [HttpGet("sistema/{id}")]
    public IActionResult GetById(int id)
    {
        var sistema = _sistemaService.GetSistemaById(id);
        if (sistema is null)
            return NoContent();
        return Ok(sistema);
    }

    [HttpPost("sistema")]
    public IActionResult Post([FromBody] NewSistemaInputModel sistema)
    {
        _sistemaService.CreateSistema(sistema);
        return CreatedAtAction(nameof(Get), sistema);

    }

    [HttpPut("sistema/{id}")]
    public IActionResult Put(int id, [FromBody] NewSistemaInputModel sistema)
    {
        if (_sistemaService.GetSistemaById(id) == null)
            return NoContent();
        _sistemaService.UpdateSistema(id, sistema);
        return Ok(_sistemaService.GetSistemaById(id));
    }

    [HttpDelete("sistema/{id}")]
    public IActionResult Delete(int id)
    {
        if (_sistemaService.GetSistemaById(id) == null)
            return NoContent();
        _sistemaService.DeleteSistema(id);
        return Ok();
    }

}
