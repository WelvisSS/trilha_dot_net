using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Aplication.InputModels;
public class NewUserInputModel
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Nick { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    
}
