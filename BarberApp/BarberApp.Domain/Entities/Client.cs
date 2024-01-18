namespace BarberApp.Domain.Entities;
public class Client
{
    public required int ClientId { get; set; }
    public required int PersonId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string CEP { get; set; }

    public required Person Person { get; set; }
    public ICollection<Request>? Requests {get;}
}
