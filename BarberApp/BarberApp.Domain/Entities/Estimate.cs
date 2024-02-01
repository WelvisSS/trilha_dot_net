namespace BarberApp.Domain.Entities;
public class Estimate
{
    public int EstimateId { get; set; }
    public DateTime Date { get; set; }
    public string? ServiceType { get; set; }
    public int Quantity { get; set; }
    // public ICollection<Service>? ServiceList { get; set; }

}
