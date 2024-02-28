using System.ComponentModel.DataAnnotations;
using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.ViewModels;
using ResTIConnect.Infrastructure.Auth;
using ResTIConnect.Infrastructure.Persistence;

namespace ResTIConnect.Aplication.Services;

public class LoginService : ILoginService
{
    private readonly IAuthService _authService;
    private readonly ResTIConnectDbContext _context;
    public LoginService(ResTIConnectDbContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }
    public LoginViewModel Login(NewLoginInputModel login)
    {
        var _passHashed = _authService.ComputeSha256Hash(login.Password);
        if (login.Email == null || login.Password == null)
            throw new ValidationException("Email e/ou senha inválidos");
        if (_context.Users.Any(x => x.Email == login.Email)
        && _context.Users.Any(x => x.Senha == _passHashed))
        {
            var _user = _context.Users.FirstOrDefault(x => x.Email == login.Email);
            var _token = _authService.GenerateJwtToken(login.Email, "user");
            return new LoginViewModel
            {
                Email = login.Email,
                Token = _token
            };
        }
        else
        {
            throw new ValidationException("Email e/ou senha inválidos");

        }


    }
}
