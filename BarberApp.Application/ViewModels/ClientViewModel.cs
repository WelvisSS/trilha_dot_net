namespace BarberApp.Application.ViewModels;

public class ClientViewModel
{
    public required int ClientId { get; set; }
    public required int PersonId {get; set;}
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string CEP { get; set; }
}
