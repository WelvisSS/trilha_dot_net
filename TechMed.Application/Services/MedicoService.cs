using TechMed.Application.Interfaces;
using TechMed.Domain.Entities;
using TechMed.Domain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application;

public class MedicoService : IMedicoService
{
    public readonly TechMedDbContext _context;

    public MedicoService(TechMedDbContext context){
        _context = context;
    }
    public Medico GetByDbId(int id){
        var _medico = _context.Medicos.Find(id);
        if (_medico == null) throw new MedicoNotFoundException();
        return _medico;
    }
    public int Create(NewMedicoInputModel medico)
    {
        var _medico = new Medico
        {
            Nome = medico.Nome,
            Cpf = medico.Cpf,
            Crm = medico.Crm,
        };
        _context.Medicos.Add(_medico);
        _context.SaveChanges();
        return _medico.MedicoId;
    }

    public void Delete(int id)
    {
        _context.Medicos.Remove(GetByDbId(id));
        _context.SaveChanges();
    }

    public List<MedicoViewModel> GetAll()
    {
        var _medicos = _context.Medicos.Select(m => new MedicoViewModel
        {
            MedicoId = m.MedicoId,
            Nome = m.Nome,
        }).ToList();

        return _medicos;
    }

    public MedicoViewModel? GetById(int id)
    {
        var _medico = GetByDbId(id);

        var MedicoViewModel = new MedicoViewModel
        {
            MedicoId = _medico.MedicoId,
            Nome = _medico.Nome
        };
        return MedicoViewModel;
    }

    public void Update(int id, NewMedicoInputModel medico)
    {
        var _medico = GetByDbId(id);

        _medico.Nome = medico.Nome;

        _context.Medicos.Update(_medico);

        _context.SaveChanges();
    }
}
