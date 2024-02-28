namespace BarberApp.Application.InputModels;

public class NewServiceInputModel
{
    public int RequestId { get; set; }
    public int EmployeeId { get; set; }
    public string? ServiceType { get; set; }
    public double? Amount { get; set; }
    public int? Quantity { get; set; }
    public DateTime? Date { get; set; }
}
