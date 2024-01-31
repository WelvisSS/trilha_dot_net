using TechMed.Domain.Common;

namespace TechMed.Domain.Entities;
public class Pessoa : BaseEntity
{
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
}
