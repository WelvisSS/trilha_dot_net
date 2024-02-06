using TechMed.Domain.Entities;

namespace TechMed.Application.InputModels;

public class NewPacienteInputModel
{
    public string? Nome {get; set;}
    public string? Cpf {get; set;}
    public DateTime DataNascimento { get; set; }
    // public ICollection<Atendimento>? Atendimentos {get; set;}
}
