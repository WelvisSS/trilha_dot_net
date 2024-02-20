namespace BarberApp.Application.InputModels;

public class NewEmployeeInputModel
{
    public int PersonId {get; set;}
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    
}
