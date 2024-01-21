namespace BarberApp.Domain.Entities;
public class Estimate
{
    public required int EstimateId { get; set; }
    public required int ServiceId { get; set; }
    public required int EmployeeId { get; set; }
    public required string ServieType { get; set; }
    public required double Amount { get; set; }
    public required int Quantity { get; set; }
    public required DateTime Date { get; set; }
    public required Service Service {get; set;}

}
