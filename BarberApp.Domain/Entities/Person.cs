using BarberApp.Domain.Common;

namespace BarberApp.Domain.Entities;

public class Person : BaseEntity
{
    public required int PersonId { get; set; }

}
