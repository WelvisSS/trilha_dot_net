using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;
using TechMed.Domain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application.Services;

public class AtendimentoService : IAtendimentoService
{
    private readonly TechMedDbContext _context;
    private readonly IMedicoService _medicoService;
    private readonly IPacienteService _pacienteService;
    public AtendimentoService(TechMedDbContext context, IMedicoService medicoService, IPacienteService pacienteService)
    {
        _context = context;
        _medicoService = medicoService;
        _pacienteService = pacienteService;
    }

    public int Create(NewAtendimentoInputModel atendimento)
    {
        return _medicoService.CreateAtendimento(atendimento.MedicoId, atendimento);
    }

    public void Delete(int atendimentoId)
    {
        throw new NotImplementedException();
    }

    public List<AtendimentoViewModel> GetAll()
    {
        return _context.Atendimentos.Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHoraInicio = a.DataHoraInicio,
            DataHoraFim = a.DataHoraFim,
            SuspeitaInicial = a.SuspeitaInicial,
            Diagnostico = a.Diagnostico,
            Medico = new MedicoViewModel
            {
                MedicoId = a.Medico.MedicoId,
                Nome = a.Medico.Nome
            },
            Paciente = new PacienteViewModel
            {
                PacienteId = a.Paciente.PacienteId,
                Nome = a.Paciente.Nome
            }
        }).ToList();
    }

    public List<AtendimentoViewModel> GetConsultationsAndExamsByDoctorId(int doctorId)
    {
        var atendimentos = _context.Atendimentos.Where(a => a.Medico.MedicoId == doctorId);
        return atendimentos.Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHoraInicio = a.DataHoraInicio,
            DataHoraFim = a.DataHoraFim,
            SuspeitaInicial = a.SuspeitaInicial,
            Diagnostico = a.Diagnostico,
            Medico = new MedicoViewModel
            {
                MedicoId = a.Medico.MedicoId,
                Nome = a.Medico.Nome
            },
            Paciente = new PacienteViewModel
            {
                PacienteId = a.Paciente.PacienteId,
                Nome = a.Paciente.Nome
            }
        }).ToList();
    }

    public List<AtendimentoViewModel> GetConsultationsAndExamsByPatientId(int patientId)
    {
        var atendimentos = _context.Atendimentos.Where(a => a.Paciente.PacienteId == patientId);
        return atendimentos.Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHoraInicio = a.DataHoraInicio,
            DataHoraFim = a.DataHoraFim,
            SuspeitaInicial = a.SuspeitaInicial,
            Diagnostico = a.Diagnostico,
            Medico = new MedicoViewModel
            {
                MedicoId = a.Medico.MedicoId,
                Nome = a.Medico.Nome
            },
            Paciente = new PacienteViewModel
            {
                PacienteId = a.Paciente.PacienteId,
                Nome = a.Paciente.Nome
            }
        }).ToList();
    }

    public List<AtendimentoViewModel> GetConsultationsAndExamsByDates(string inicio, string fim)
    {
        var atendimentos = _context.Atendimentos.Where(a => a.DataHoraInicio >= DateTime.Parse(inicio) && a.DataHoraFim <= DateTime.Parse(fim));
        return atendimentos.Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHoraInicio = a.DataHoraInicio,
            DataHoraFim = a.DataHoraFim,
            SuspeitaInicial = a.SuspeitaInicial,
            Diagnostico = a.Diagnostico,
            Medico = new MedicoViewModel
            {
                MedicoId = a.Medico.MedicoId,
                Nome = a.Medico.Nome
            },
            Paciente = new PacienteViewModel
            {
                PacienteId = a.Paciente.PacienteId,
                Nome = a.Paciente.Nome
            }
        }).ToList();
    }

    public AtendimentoViewModel? GetById(int id)
    {
        var atendimentoDB = _context.Atendimentos.Find(id);
        if (atendimentoDB is null)
            throw new AtendimentoNotFoundException();

        var medicoVM = _medicoService.GetById(atendimentoDB.Medico.MedicoId);
        var pacienteVM = _pacienteService.GetById(atendimentoDB.Paciente.PacienteId);

        if (medicoVM is null || pacienteVM is null)
            return null;

        return new AtendimentoViewModel
        {
            AtendimentoId = atendimentoDB.AtendimentoId,
            DataHoraInicio = atendimentoDB.DataHoraInicio,
            DataHoraFim = atendimentoDB.DataHoraFim,
            SuspeitaInicial = atendimentoDB.SuspeitaInicial,
            Diagnostico = atendimentoDB.Diagnostico,
            Medico = medicoVM,
            Paciente = pacienteVM
        };
    }

    public List<AtendimentoViewModel> GetByMedicoId(int medicoId)
    {

        throw new NotImplementedException();
    }

    public List<AtendimentoViewModel> GetByPacienteId(int pacienteId)
    {

        throw new NotImplementedException();
    }

    public void Update(int id, NewAtendimentoInputModel atendimento)
    {
        throw new NotImplementedException();

    }
}
