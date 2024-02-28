using BarberApp.Domain.Common;

namespace BarberApp.Domain.Entities;

public class PhysicalPerson : Person
{
    public string? CPF { get; set; }
}
