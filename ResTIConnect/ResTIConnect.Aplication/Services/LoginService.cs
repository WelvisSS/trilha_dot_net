using System.ComponentModel.DataAnnotations;
using ResTIConnect.Aplication.InputModels;
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
    public string Login(NewLoginInputModel login)
    {
        if (login.Email == null || login.Password == null)
            throw new ValidationException("Email e/ou senha inválidos");
        if (_context.Users.Any(x => x.Email == login.Email) && _context.Users.Any(x => x.Senha == _authService.ComputeSha256Hash(login.Password)));
        return "Login efetuado com sucesso";
    }
}
