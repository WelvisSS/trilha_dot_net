using BarberApp.Domain.Common;

namespace BarberApp.Domain.Entities;

public class LegalPerson : Person
{
    public required string CNPJ { get; set; }
}
