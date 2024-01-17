namespace BarberApp.Domain.Entities;
public class PhysicalPerson
{
    public required int PhysicalPersonId { get; set; }

    public required Person Person { get; set; }
    public required string CPF { get; set; }
}
