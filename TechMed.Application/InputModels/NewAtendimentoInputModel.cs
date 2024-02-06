using TechMed.Domain.Entities;

namespace TechMed.Application.InputModels;

public class NewAtendimentoInputModel
{
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public string? SuspeitaInicial { get; set; }
    public string? Diagnostico { get; set; }
    public int PacienteId {get; set;}
    public int MedicoId {get; set;}
    // public ICollection<Exame>? Exames { get; set; }
}
