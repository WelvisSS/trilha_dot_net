namespace BarberApp.Application.InputModels;

public class NewClientInputModel
{
    public int PersonId {get; set;}
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string CEP { get; set; }
    // public ICollection<Request>? Requests { get; }
}
