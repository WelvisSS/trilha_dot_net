namespace BarberApp.Domain.Entities;
public class Client : Person
{
    public required int ClientId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string CEP { get; set; }

}
