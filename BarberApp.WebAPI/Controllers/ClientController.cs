using BarberApp.Application.InputModels;
using BarberApp.Application.Services.Interfaces;
using BarberApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TechMed.WebAPI.Controllers;


[ApiController]
[Route("/api/v0.1/")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    public List<ClientViewModel> Clients => _clientService.GetAll();
    public ClientController(IClientService service) => _clientService = service;


    [HttpGet("clients")]
    public IActionResult Get()
    {
        return Ok(Clients);

    }

    [HttpGet("clients/{id}")]
    public IActionResult Get(int id)
    {
        ClientViewModel? client = _clientService.GetById(id);

        if (client is null)
        {
            return NoContent();
        }
        return Ok(client);
    }

    [HttpPost("clients")]
    public IActionResult Post([FromBody] NewClientInputModel client)
    {
        _clientService.Create(client);
        return CreatedAtAction(nameof(Get), client);

    }

    [HttpPut("clients/{id}")]
    public IActionResult Put(int id, [FromBody] NewClientInputModel client)
    {
        if (_clientService.GetById(id) == null)
            return NoContent();

        _clientService.Update(id, client);
        return Ok(client);
    }

    [HttpDelete("clients/{id}")]
    public IActionResult Delete(int id)
    {
        _clientService.Delete(id);
        return Ok();
    }
}
