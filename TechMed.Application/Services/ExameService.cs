using TechMed.Application.InputModels;
using TechMed.Application.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;
using TechMed.Domain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application;

public class ExameService : IExameService
{
    public readonly TechMedDbContext _context;

    public ExameService(TechMedDbContext context){
        _context = context;
    }
    public Exame GetByDbId(int id){
        var _exame = _context.Exames.Find(id);
        if (_exame == null) throw new ExameNotFoundException();
        return _exame;
    }
    public int Create(NewExameInputModel exame)
    {
        var _exame = new Exame
        {
            Nome = exame.Nome,
            DataHora = exame.DataHora,
            Valor = exame.Valor,
            Local = exame.Local,
            ResultadoDescricao = exame.ResultadoDescricao
        };
        _context.Exames.Add(_exame);
        _context.SaveChanges();
        return _exame.ExameId;
    }

    public void Delete(int id)
    {
        _context.Exames.Remove(GetByDbId(id));
        _context.SaveChanges();
    }

    public List<ExameViewModel> GetAll()
    {
        var _exames = _context.Exames.Select(m => new ExameViewModel
        {
            ExameId = m.ExameId,
            Nome = m.Nome,
            DataHora = m.DataHora,
            Valor = m.Valor,
            Local = m.Local,
            ResultadoDescricao = m.ResultadoDescricao,
        }).ToList();

        return _exames;
    }

    public ExameViewModel? GetById(int id)
    {
        var _exame = GetByDbId(id);

        var ExameViewModel = new ExameViewModel
        {
            ExameId = _exame.ExameId,
            Nome = _exame.Nome,
            DataHora = _exame.DataHora,
            Valor = _exame.Valor,
            Local = _exame.Local,
            ResultadoDescricao = _exame.ResultadoDescricao,
        };
        return ExameViewModel;
    }

    public void Update(int id, NewExameInputModel exame)
    {
        var _exame = GetByDbId(id);

        _exame.Nome = exame.Nome;

        _context.Exames.Update(_exame);

        _context.SaveChanges();
    }
}
