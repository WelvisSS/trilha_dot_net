using BarberApp.Domain.Common;

namespace BarberApp.Domain.Entities;

public class LegalPerson : Person
{
    public string? CNPJ { get; set; }
}
