using TechMed.Domain.Entities;

namespace TechMed.Application.ViewModels;

public class ExameViewModel
{
    public int ExameId { get; set; }
    public string? Nome { get; set; }
    public DateTime DataHora { get; set; }
    public decimal Valor { get; set; }
    public string? Local { get; set; }
    public string? ResultadoDescricao {get; set;}
    public int AtendimentoId {get;set;}
    // public Atendimento? Atendimento {get;set;}
}
