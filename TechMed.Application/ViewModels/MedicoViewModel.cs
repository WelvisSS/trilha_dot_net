using TechMed.Domain.Entities;

namespace TechMed.Application.ViewModels;

public class MedicoViewModel
{
    public int MedicoId {get; set;}
    public string? Nome { get; set; }
    public ICollection<AtendimentoViewModel>? Atendimentos {get; set;}
}
