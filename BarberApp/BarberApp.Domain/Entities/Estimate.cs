namespace BarberApp.Domain.Entities;
public class Estimate
{
    public required int EstimateId { get; set; }
    public required DateTime Date { get; set; }
    public required string ServieType { get; set; }
    public required int Quantity { get; set; }
    
    public required ICollection<Service> ServiceList {get; set;}
    
}
