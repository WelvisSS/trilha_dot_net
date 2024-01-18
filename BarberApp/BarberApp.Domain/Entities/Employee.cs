namespace BarberApp.Domain.Entities;
public class Employee
{
    public required int EmployeeId { get; set; }
    public required int PersonId { get; set; }
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }

    public required Person Person { get; set; }

    public required int ServiceId { get; set; }
    public ICollection<Service>? Services {get; set;}
}
