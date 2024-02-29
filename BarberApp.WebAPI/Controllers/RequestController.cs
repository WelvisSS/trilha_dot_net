using Microsoft.AspNetCore.Mvc;
using BarberApp.Application.Services.Interfaces;
using BarberApp.Application.ViewModels;
using BarberApp.Application.InputModels;
using Microsoft.AspNetCore.Authorization;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class RequestControllers : ControllerBase
{
    private readonly IRequestService _requestService;
    public List<RequestViewModel> Requests => _requestService.GetAll();
    public RequestControllers(IRequestService service) => _requestService = service;


    [HttpGet("requests")]
    public IActionResult Get()
    {
        return Ok(Requests);

    }

    [HttpGet("requests/{id}")]
    public IActionResult Get(int id)
    {
        RequestViewModel? request = _requestService.GetById(id);

        if (request is null)
        {
            return NoContent();
        }
        return Ok(request);
    }

    [HttpGet("client/{id}/requests")]
    public IActionResult GetByClientId(int id)
    {
        List<RequestViewModel> requests = _requestService.GetByClientId(id);

        if (requests is null)
        {
            return NoContent();
        }
        return Ok(requests);
    }

    [HttpPost("requests")]
    public IActionResult Post([FromBody] NewRequestInputModel request)
    {
        _requestService.Create(request);
        return CreatedAtAction(nameof(Get), request);

    }

    [HttpPut("requests/{id}")]
    public IActionResult Put(int id, [FromBody] NewRequestInputModel request)
    {
        if (_requestService.GetById(id) == null)
            return NoContent();

        _requestService.Update(id, request);
        return Ok(request);
    }

    [HttpDelete("requests/{id}")]
    public IActionResult Delete(int id)
    {
        _requestService.Delete(id);
        return Ok();
    }


}
