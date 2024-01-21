namespace BarberApp.Domain.Entities;
public class Estimate
{
    public required int EstimateId { get; set; }
    public required DateTime Date { get; set; }
    public required string Description { get; set; }
    public required string ServieType { get; set; }
    
    public required ICollection<Service> Service {get; set;}
}
