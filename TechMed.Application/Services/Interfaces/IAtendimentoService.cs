using System.Data.Common;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces;

public interface IAtendimentoService
{
    public List<AtendimentoViewModel> GetAll();
    public AtendimentoViewModel? GetById(int id);
    public List<AtendimentoViewModel> GetByPacienteId(int pacienteId);
    public List<AtendimentoViewModel> GetByMedicoId(int medicoId);
    public List<AtendimentoViewModel> GetConsultationsAndExamsByDoctorId(int doctorId);

    public List<AtendimentoViewModel> GetConsultationsAndExamsByPatientId(int doctorId);

    public List<AtendimentoViewModel> GetConsultationsAndExamsByDates(string inicio, string fim);
    public int Create(NewAtendimentoInputModel atendimento);
    void Update(int id, NewAtendimentoInputModel atendimento);
    void Delete(int atendimentoId);
}
