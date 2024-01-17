namespace BarberApp.Domain.Entities;
public class Person
{
    public required int PersonId { get; set; }
    public required LegalPerson LegalPerson { get; set; }
    public required PhysicalPerson PhysicalPerson { get; set; }

    public required Client Client { get; set; }

    public required Employee Employee { get; set; }
}
