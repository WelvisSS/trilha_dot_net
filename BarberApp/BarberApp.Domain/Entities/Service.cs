namespace BarberApp.Domain.Entities;
public class Service
{
    public int ServiceId { get; set; }
    public int RequestId { get; set; }
    public int EmployeeId { get; set; }
    public string? ServiceType { get; set; }
    public double Amount { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public Request? Request { get; set; }
    public Employee? Employee { get; set; }
    // public ICollection<Estimate>? EstimateList {get; set;}
}
