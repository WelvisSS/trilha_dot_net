
using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.Services.Interfaces;
using ResTIConnect.Aplication.ViewModels;
using ResTIConnect.Domain;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;

namespace ResTIConnect.Aplication.Services;

public class PerfilService : IPerfilService
{
    private readonly ResTIConnectDbContext _context;
    public PerfilService(ResTIConnectDbContext context)
    {
        _context = context;
    }

    private Perfil GetByDbId(int id)
    {
        var _perfil = _context.Perfis.Find(id);

        if (_perfil is null)
            throw new PerfilNotFoundException();

        return _perfil;
    }

    public int Create(NewPerfilInputModel perfil)
    {
        var _perfil = new Perfil
        {
            Descricao = perfil.Descricao,
            Permissoes = perfil.Permissoes
        };
        _context.Perfis.Add(_perfil);

        _context.SaveChanges();

        return _perfil.PerfilId;
    }

    public void Delete(int id)
    {
        _context.Perfis.Remove(GetByDbId(id));

        _context.SaveChanges();
    }

    public List<PerfilViewModel> GetAll()
    {
        var _perfis = _context.Perfis.Select(m => new PerfilViewModel
        {
            PerfilId = m.PerfilId,
            Descricao = m.Descricao
        }).ToList();

        return _perfis;
    }

    public PerfilViewModel? GetById(int id)
    {
        var _perfil = GetByDbId(id);

        var PerfilViewModel = new PerfilViewModel
        {
            PerfilId = _perfil.PerfilId,
            Descricao = _perfil.Descricao
        };
        return PerfilViewModel;
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

