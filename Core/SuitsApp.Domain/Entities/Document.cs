using SuitsApp.Domain.Common;

namespace SuitsApp.Domain.Entities;
public class Document : BaseEntity
{
    public int DocumentId { get; set; }
    // public DateTime ChangeDate { get; set; }
    // public int Code { get; set; }
    // public string? Type { get; set; }
    public string? Description { get; set; }
}
