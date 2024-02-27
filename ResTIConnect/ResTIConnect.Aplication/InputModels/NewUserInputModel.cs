using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Aplication.InputModels;
public class NewUserInputModel
{
    public int UserId { get; set; }
    public required string Name { get; set; }
    public required string Nick { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Phone { get; set; }
    
}
