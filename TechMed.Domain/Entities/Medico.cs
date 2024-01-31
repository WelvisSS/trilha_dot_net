namespace TechMed.Domain.Entities;
public class Medico : Pessoa
{
    public int MedicoId { get; set; }
    public string? Crm { get; set; }

    public ICollection<Atendimento>? Atendimentos {get; set;}
}
