using TechMed.Domain.Common;

namespace TechMed.Domain.Entities;
public class Exame : BaseEntity
{
    public int ExameId { get; set; }
    public string? Nome { get; set; }
    public DateTime DataHora { get; set; }
    public decimal Valor { get; set; }
    public string? Local { get; set; }
    public string? ResultadoDescricao {get; set;}
    public Atendimento? Atendimento {get;set;}
    public int AtendimentoId {get;set;}

}
