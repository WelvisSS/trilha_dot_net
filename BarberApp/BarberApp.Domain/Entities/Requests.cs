namespace BarberApp.Domain.Entities;
public class Request
{
    public required int Requestd { get; set; }
    public required int ClientId { get; set; }
    public required DateTime Date { get; set; }
    public required double RequiredAmount { get; set; }
}
