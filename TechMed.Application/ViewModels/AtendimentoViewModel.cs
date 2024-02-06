using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;

namespace TechMed.Application.ViewModels;

public class AtendimentoViewModel
{
    public int AtendimentoId { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public string? SuspeitaInicial { get; set; }
    public string? Diagnostico { get; set; }
    public PacienteViewModel Paciente { get; set; } = null!;
    public MedicoViewModel Medico { get; set; } = null!;

    // public ICollection<Exame>? Exames { get; set; }
}
