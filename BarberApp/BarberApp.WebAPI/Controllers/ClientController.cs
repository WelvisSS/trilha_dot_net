using Microsoft.AspNetCore.Mvc;
using BarberApp.Domain.Entities;
using BarberApp.Domain.Interfaces;
namespace BarberApp.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ClientController : ControllerBase
{
    private readonly IClientCollection _clients;
    public List<Client> Clients => _clients.GetAll().ToList();
    public ClientController(IDatabaseFake dbFake) => _clients = dbFake.ClientsCollection;

    [HttpGet("clients")]
    public IActionResult Get()
    {
        return Ok(Clients);
    }

    [HttpGet("client/{id}")]
    public IActionResult GetById(int id)
    {
        var client = _clients.GetById(id);
        return Ok(client);
    }

    [HttpPost("client")]
    public IActionResult Post([FromBody] Client client)
    {
        _clients.Create(client);
        return CreatedAtAction(nameof(Get), client);
    }

    [HttpPut("client/{id}")]
    public IActionResult Put(int id, [FromBody] Client client)
    {
        if (_clients.GetById(id) == null)
            return NoContent();
        _clients.Update(id, client);
        return Ok(_clients.GetById(id));
    }

    [HttpDelete("client/{id}")]
    public IActionResult Delete(int id)
    {
        if (_clients.GetById(id) == null)
            return NoContent();
        _clients.Delete(id);
        return Ok();
    }
}
