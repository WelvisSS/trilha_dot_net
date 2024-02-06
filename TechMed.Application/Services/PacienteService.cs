using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;
using TechMed.Domain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application.Services;

public class PacienteService : IPacienteService
{
    public readonly TechMedDbContext _context;

    public PacienteService(TechMedDbContext context){
        _context = context;
    }
    public Paciente GetByDbId(int id){
        var _paciente = _context.Pacientes.Find(id);
        if (_paciente == null) throw new PacienteNotFoundException();
        return _paciente;
    }
    public int Create(NewPacienteInputModel paciente)
    {
        var _paciente = new Paciente
        {
            Nome = paciente.Nome,
            Cpf = paciente.Cpf,
            DataNascimento = paciente.DataNascimento,
        };
        _context.Pacientes.Add(_paciente);
        _context.SaveChanges();
        return _paciente.PacienteId;
    }

    public void Delete(int id)
    {
        _context.Pacientes.Remove(GetByDbId(id));
        _context.SaveChanges();
    }

    public List<PacienteViewModel> GetAll()
    {
        var _pacientes = _context.Pacientes.Select(m => new PacienteViewModel
        {
            PacienteId = m.PacienteId,
            Nome = m.Nome,
            DataNascimento = m.DataNascimento,
        }).ToList();

        return _pacientes;
    }

    public PacienteViewModel? GetById(int id)
    {
        var _paciente = GetByDbId(id);

        var PacienteViewModel = new PacienteViewModel
        {
            PacienteId = _paciente.PacienteId,
            Nome = _paciente.Nome
        };
        return PacienteViewModel;
    }

    public void Update(int id, NewPacienteInputModel paciente)
    {
        var _paciente = GetByDbId(id);

        _paciente.Nome = paciente.Nome;

        _context.Pacientes.Update(_paciente);

        _context.SaveChanges();
    }
}
