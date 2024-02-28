using System.ComponentModel.DataAnnotations;
using BarberApp.Application.InputModels;
using BarberApp.Application.Services.Interfaces;
using BarberApp.Application.ViewModels;
using BarberApp.Infrastructure.Auth;
using BarberApp.Infrastructure.Persistence.Context;

namespace BarberApp.Application;

public class LoginService : ILoginService
{
    private readonly IAuthService _authService;
    private readonly BarberAppDbContext _context;
    public LoginService(BarberAppDbContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }
    public LoginViewModel LoginClient(NewLoginInputModel login)
    {
        var _passHashed = _authService.ComputeSha256Hash(login.password);
        if (login.email == null || login.password == null)
            throw new ValidationException("Email e/ou senha inválidos");
        if (_context.Clients.Any(x => x.Email == login.email)
        && _context.Clients.Any(x => x.Password == _passHashed))
        {
            var _user = _context.Clients.FirstOrDefault(x => x.Email == login.email);
            var _token = _authService.GenerateJwtToken(login.email, _user.Role);
            return new LoginViewModel
            {
                email = login.email,
                token = _token
            };
        }
        else
        {
            throw new ValidationException("Email e/ou senha inválidos");

        }
    }
      public LoginViewModel LoginEmployee(NewLoginInputModel login)
    {
        var _passHashed = _authService.ComputeSha256Hash(login.password);
        if (login.email == null || login.password == null)
            throw new ValidationException("Email e/ou senha inválidos");
        if (_context.Employees.Any(x => x.Email == login.email)
        && _context.Employees.Any(x => x.Password == _passHashed))
        {
            var _user = _context.Employees.FirstOrDefault(x => x.Email == login.email);
            var _token = _authService.GenerateJwtToken(login.email, _user.Role);
            return new LoginViewModel
            {
                email = login.email,
                token = _token
            };
        }
        else
        {
            throw new ValidationException("Email e/ou senha inválidos");

        }


    }
}
