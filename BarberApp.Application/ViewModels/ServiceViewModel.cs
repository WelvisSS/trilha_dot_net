namespace BarberApp.Application.ViewModels;

public class ServiceViewModel
{
    public required string ServiceType { get; set; }
    public required double Amount { get; set; }
    public required int Quantity { get; set; }
    public required DateTime Date { get; set; }

}
