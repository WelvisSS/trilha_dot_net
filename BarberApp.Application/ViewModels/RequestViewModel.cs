namespace BarberApp.Application.ViewModels;

public class RequestViewModel
{
    public int RequestId { get; set; }
    public int ClientId { get; set; }
    public DateTime? Date { get; set; }
    public double? RequiredAmount { get; set; }

}
