namespace BarberApp.Domain.Entities;

public class Employee : Person
{
    public int EmployeeId { get; set; }
    public string? PhoneNumber { get; set; }
    public ICollection<Service>? Services { get; set; }
}
