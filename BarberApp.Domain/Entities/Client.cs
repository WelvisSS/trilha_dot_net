namespace BarberApp.Domain.Entities;

public class Client : Person
{
    public int ClientId { get; set; }
    public string? CEP { get; set; }
    public ICollection<Request>? Requests { get; }
}
