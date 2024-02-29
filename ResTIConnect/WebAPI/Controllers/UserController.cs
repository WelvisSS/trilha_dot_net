using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.Services.Interfaces;
using ResTIConnect.Aplication.ViewModels;
using ResTIConnect.Aplication;
using Microsoft.AspNetCore.Authorization;


namespace ResTIConnect.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public List<UserViewModel> Users => _userService.GetAll().ToList();
    public UserController(IUserService service) => _userService = service;

    [HttpGet("users")]
    public IActionResult Get()
    {
        return Ok(Users);
    }

    [HttpGet("user/{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);
        if (user is null)
            return NoContent();
        return Ok(user);
    }

    [HttpPost("user")]
    [AllowAnonymous]
    public IActionResult Post([FromBody] NewUserInputModel user)
    {
        _userService.Create(user);
        return CreatedAtAction(nameof(Get), user);
    }

    [HttpPut("user/{id}")]
    public IActionResult Put(int id, [FromBody] NewUserInputModel user)
    {
        if (_userService.GetById(id) == null)
            return NoContent();
        _userService.Update(id, user);
        return Ok(_userService.GetById(id));
    }

    [HttpDelete("user/{id}")]
    public IActionResult Delete(int id)
    {
        if (_userService.GetById(id) == null)
            return NoContent();
        _userService.Delete(id);
        return Ok();
    }
}
