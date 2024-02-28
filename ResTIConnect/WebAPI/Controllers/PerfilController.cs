using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.Services.Interfaces;
using ResTIConnect.Aplication.ViewModels;

namespace ResTIConnect.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class PerfilController : ControllerBase
{
    private readonly IPerfilService _perfilService;
    public List<PerfilViewModel> Perfis => _perfilService.GetAll().ToList();
    public PerfilController(IPerfilService service) => _perfilService = service;

    [HttpGet("perfis")]
    public IActionResult Get()
    {
        return Ok(Perfis);
    }

    [HttpGet("perfil/{id}")]
    public IActionResult GetById(int id)
    {
        var perfil = _perfilService.GetById(id);
        if (perfil is null)
            return NoContent();
        return Ok(perfil);
    }

    [HttpPost("perfil")]
    public IActionResult Post([FromBody] NewPerfilInputModel perfil)
    {
        _perfilService.Create(perfil);
        return CreatedAtAction(nameof(Get), perfil);

    }

    [HttpPut("perfil/{id}")]
    public IActionResult Put(int id, [FromBody] NewPerfilInputModel perfil)
    {
        if (_perfilService.GetById(id) == null)
            return NoContent();
        _perfilService.Update(id, perfil);
        return Ok(_perfilService.GetById(id));
    }

    [HttpDelete("perfil/{id}")]
    public IActionResult Delete(int id)
    {
        if (_perfilService.GetById(id) == null)
            return NoContent();
        _perfilService.Delete(id);
        return Ok();
    }
}
