namespace BarberApp.Application.InputModels;

public class NewServiceInputModel
{
    public required int RequestId { get; set; }
    public required int EmployeeId { get; set; }
    public required string ServiceType { get; set; }
    public required double Amount { get; set; }
    public required int Quantity { get; set; }
    public required DateTime Date { get; set; }
}
