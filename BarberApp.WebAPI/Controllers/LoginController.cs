using BarberApp.Application.InputModels;
using BarberApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberApp.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("client/login")]
    public IActionResult ClientLogin([FromBody] NewLoginInputModel login)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _loginService.LoginClient(login);
        return Ok(result);

    }

     [HttpPost("employee/login")]
    public IActionResult EmployeeLogin([FromBody] NewLoginInputModel login)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _loginService.LoginEmployee(login);
        return Ok(result);

    }

}