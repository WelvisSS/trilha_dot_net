using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.Services.Interfaces;
using ResTIConnect.Aplication.ViewModels;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.WebAPI.Controllers;


[ApiController]
[Route("/api/v0.1/")]
public class EnderecoController : ControllerBase
{
    private readonly IEnderecoService _enderecoService;
    public List<EnderecoViewModel> Enderecos => _enderecoService.GetAllEnderecos();
    public EnderecoController(IEnderecoService service) => _enderecoService = service;

    [HttpGet("Enderecos")]
    public IActionResult Get()
    {
        return Ok(Enderecos);
    }

    [HttpGet("endereco/{id}")]
    public IActionResult GetById(int id)
    {
        var endereco = _enderecoService.GetEnderecoById(id);
        if (endereco is null)
            return NoContent();
        return Ok(endereco);
    }

    [HttpPost("endereco")]
    public IActionResult Post([FromBody] NewEnderecoInputModel endereco)
    {
        _enderecoService.CreateEndereco(endereco);
        return CreatedAtAction(nameof(Get), endereco);

    }

    [HttpPut("endereco/{id}")]
    public IActionResult Put(int id, [FromBody] NewEnderecoInputModel endereco)
    {
        if (_enderecoService.GetEnderecoById(id) == null)
            return NoContent();
        _enderecoService.UpdateEndereco(id, endereco);
        return Ok(_enderecoService.GetEnderecoById(id));
    }

    [HttpDelete("endereco/{id}")]
    public IActionResult Delete(int id)
    {
        if (_enderecoService.GetEnderecoById(id) == null)
            return NoContent();
        _enderecoService.DeleteEndereco(id);
        return Ok();
    }
}

