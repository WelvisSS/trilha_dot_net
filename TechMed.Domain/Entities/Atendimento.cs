using TechMed.Domain.Common;

namespace TechMed.Domain.Entities;
public class Atendimento : BaseEntity
{
    public int AtendimentoId { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; } 
    public string? SuspeitaInicial { get; set; }
    public string? Diagnostico { get; set; }
    public int MedicoId { get; set; }
    public int PacienteId { get; set; }
}
