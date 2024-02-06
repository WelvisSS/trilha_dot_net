using TechMed.Domain.Entities;

namespace TechMed.Application.ViewModels;

public class PacienteViewModel
{
    public int PacienteId {get; set;}
    public string? Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    // public ICollection<Atendimento>? Atendimentos {get; set;}
}
