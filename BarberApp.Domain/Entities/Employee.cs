namespace BarberApp.Domain.Entities;

public class Employee : Person
{
    public required int EmployeeId { get; set; }

    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }

    public ICollection<Service>? Services { get; set; }
}
