using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;
using TechMed.Domain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application.Services;

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

    public int CreateAtendimento(int medicoId, NewAtendimentoInputModel atendimento)
    {
         var medico = _context.Medicos.Find(medicoId);
    if (medico is null)
      throw new MedicoNotFoundException();

    var paciente = _context.Pacientes.Find(atendimento.PacienteId);
    if (paciente is null)
      throw new PacienteNotFoundException();

    var _atendimento = new Atendimento
    {
      DataHoraInicio = atendimento.DataHoraInicio,
      Medico = medico,
      Paciente = paciente,
      SuspeitaInicial = atendimento.SuspeitaInicial,
      Diagnostico = atendimento.Diagnostico,
    };
    _context.Atendimentos.Add(_atendimento);
        _context.SaveChanges();
        return _atendimento.AtendimentoId;
    }
}
