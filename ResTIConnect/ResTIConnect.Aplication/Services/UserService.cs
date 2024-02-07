
using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.Services.Interfaces;
using ResTIConnect.Aplication.ViewModels;
using ResTIConnect.Domain;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;

namespace ResTIConnect.Aplication.Services;

public class UserService : IUserService 
{
    private readonly ResTIConnectDbContext _context;
    public UserService(ResTIConnectDbContext context)
    {
        _context = context;
    }

    private Perfil GetByDbId(int id)
    {
        var _user = _context.Users.Find(id);

        if (_user is null)
            throw new PerfilNotFoundException();

        return _user;
    }

    public int Create(NewUserInputModel user)
    {
        var _user = new User
        {
            // Descricao = perfil.Descricao,
            // Permissoes = perfil.Permissoes
        };
        _context.Users.Add(_user);

        _context.SaveChanges();

        return _user.UserId;
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
            // PerfilId = m.PerfilId,
            // Descricao = m.Descricao
        }).ToList();

        return _users;
    }

    public UserViewModel? GetById(int id)
    {
        var _user = GetByDbId(id);

        var UserViewModel = new UserViewModel
        {
            // PerfilId = _perfil.PerfilId,
            // Descricao = _perfil.Descricao
        };
        return UserViewModel;
    }

    public void Update(int id, NewPerfilInputModel perfil)
    {
        var _perfil = GetByDbId(id);

        _perfil.Descricao = perfil.Descricao;
        _perfil.Permissoes = perfil.Permissoes;

        _context.Perfis.Update(_perfil);

        _context.SaveChanges();
    }
}

