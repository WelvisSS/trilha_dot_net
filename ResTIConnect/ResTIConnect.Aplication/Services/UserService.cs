
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;
using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.Services.Interfaces;
using ResTIConnect.Aplication.ViewModels;
using ResTIConnect.Domain;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infrastructure.Auth;
using ResTIConnect.Infrastructure.Persistence;

namespace ResTIConnect.Aplication.Services;

public class UserService : IUserService
{
    private readonly IAuthService _authService;
    private readonly ResTIConnectDbContext _context;
    public UserService(ResTIConnectDbContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    private User GetByDbId(int id)
    {
        var _user = _context.Users.Find(id);

        if (_user is null)
            throw new PerfilNotFoundException();

        return _user;
    }

    public int Create(NewUserInputModel user)
    {
        // using (var sha256 = SHA256.Create())
        // {
        //     var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
        //     var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        //     user.Password = hash;
        // }
        user.Password = _authService.ComputeSha256Hash(user.Password);
        var _user = new User
        {

            Nome = user.Name,
            UsuarioId = user.UserId,
            Apelido = user.Nick,
            Email = user.Email,
            Senha = user.Password,
            Telefone = user.Phone,

        };
        _context.Users.Add(_user);

        _context.SaveChanges();

        return _user.UsuarioId;
    }

    public void Delete(int id)
    {
        _context.Users.Remove(GetByDbId(id));

        _context.SaveChanges();
    }

    public List<UserViewModel> GetAll()
    {
        var _users = _context.Users.Select(m => new UserViewModel
        {
            UserId = m.UsuarioId,
            Name = m.Nome,
            Nick = m.Apelido,
            Email = m.Email,
            Phone = m.Telefone
        }).ToList();

        return _users;
    }

    public UserViewModel? GetById(int id)
    {
        var _user = GetByDbId(id);

        var UserViewModel = new UserViewModel
        {
            UserId = _user.UsuarioId,
            Name = _user.Nome,
            Nick = _user.Apelido,
            Email = _user.Email,
            Phone = _user.Telefone
        };
        return UserViewModel;
    }

    public void Update(int id, NewUserInputModel user)
    {
        var _user = GetByDbId(id);

        _user.Nome = user.Name;
        _user.Email = user.Email;
        _user.Telefone = user.Phone;

        _context.Users.Update(_user);

        _context.SaveChanges();
    }
}

