namespace BarberApp.Application.InputModels;

public class NewRequestInputModel
{
    public int RequestId { get; set; }
    public int ClientId { get; set; }
    public DateTime? Date { get; set; }
    public double? RequiredAmount { get; set; }
}
