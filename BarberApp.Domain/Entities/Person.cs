using BarberApp.Domain.Common;

namespace BarberApp.Domain.Entities;

public class Person : BaseEntity
{
    public int PersonId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }

}
