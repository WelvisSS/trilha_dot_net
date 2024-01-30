using SuitsApp.Domain.Common;

namespace SuitsApp.Domain.Entities;
public abstract class Person : BaseEntity
{
    public string? Name { get; set; }
    public string? CPF { get; set; }
    public DateTime? BirthDate { get; set; }

}
