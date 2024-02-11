namespace BarberApp.Application.ViewModels;

public class RequestViewModel
{
    public required int RequestId { get; set; }
    public required int ClientId { get; set; }
    public required DateTime Date { get; set; }
    public required double RequiredAmount { get; set; }

}
