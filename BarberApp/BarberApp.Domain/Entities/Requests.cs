namespace BarberApp.Domain.Entities;
public class Request
{
    public required int RequestId { get; set; }
    public required DateTime Date { get; set; }
    public required double RequiredAmount { get; set; }
    public required Client Client {get; set;}

}
