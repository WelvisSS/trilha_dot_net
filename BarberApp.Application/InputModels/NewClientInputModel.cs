namespace BarberApp.Application.InputModels;

public class NewClientInputModel
{
    public int PersonId {get; set;}
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    public string? CEP { get; set; }
    // public ICollection<Request>? Requests { get; }
}
