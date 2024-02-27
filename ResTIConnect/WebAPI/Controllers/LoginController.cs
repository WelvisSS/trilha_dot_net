using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Aplication;
using ResTIConnect.Aplication.InputModels;

namespace ResTIConnect.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] NewLoginInputModel login)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _loginService.Login(login);
        return Ok(result);

    }

}
