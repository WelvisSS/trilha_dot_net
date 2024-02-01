using Microsoft.AspNetCore.Mvc;
using BarberApp.Domain.Entities;
using BarberApp.Domain.Interfaces;
namespace BarberApp.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class EstimateController : ControllerBase
{
    private readonly IEstimateCollection _estimate;
    public List<Estimate> Estimate => _estimate.GetAll().ToList();
    public EstimateController(IDatabaseFake dbFake) => _estimate = dbFake.EstimateCollection;

    [HttpGet("estimate")]
    public IActionResult Get()
    {
        return Ok(Estimate);
    }

    [HttpGet("estimate/{id}")]
    public IActionResult GetById(int id)
    {
        var estimate = _estimate.GetById(id);
        return Ok(estimate);
    }

    [HttpPost("estimate")]
    public IActionResult Post([FromBody] Estimate estimate)
    {
        _estimate.Create(estimate);
        return CreatedAtAction(nameof(Get), estimate);

    }

    [HttpPut("estimate/{id}")]
    public IActionResult Put(int id, [FromBody] Estimate estimate)
    {
        if (_estimate.GetById(id) == null)
            return NoContent();
        _estimate.Update(id, estimate);
        return Ok(_estimate.GetById(id));
    }

    [HttpDelete("estimate/{id}")]
    public IActionResult Delete(int id)
    {
        if (_estimate.GetById(id) == null)
            return NoContent();
        _estimate.Delete(id);
        return Ok();
    }
}
