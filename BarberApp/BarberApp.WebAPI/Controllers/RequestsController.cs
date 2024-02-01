using Microsoft.AspNetCore.Mvc;
using BarberApp.Domain.Entities;
using BarberApp.Domain.Interfaces;
namespace BarberApp.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class RequestsController : ControllerBase
{
    private readonly IRequestCollection _requests;
    public List<Request> Requests => _requests.GetAll().ToList();
    public RequestsController(IDatabaseFake dbFake) => _requests = dbFake.RequestsCollection;

    [HttpGet("requests")]
    public IActionResult Get()
    {
        return Ok(Request);
    }

    [HttpGet("request/{id}")]
    public IActionResult GetById(int id)
    {
        var request = _requests.GetById(id);
        return Ok(request);
    }

    [HttpPost("request")]
    public IActionResult Post([FromBody] Request request)
    {
        _requests.Create(request);
        return CreatedAtAction(nameof(Get), request);

    }

    [HttpPut("request/{id}")]
    public IActionResult Put(int id, [FromBody] Request request)
    {
        if (_requests.GetById(id) == null)
            return NoContent();
        _requests.Update(id, request);
        return Ok(_requests.GetById(id));
    }

    [HttpDelete("request/{id}")]
    public IActionResult Delete(int id)
    {
        if (_requests.GetById(id) == null)
            return NoContent();
        _requests.Delete(id);
        return Ok();
    }
}
