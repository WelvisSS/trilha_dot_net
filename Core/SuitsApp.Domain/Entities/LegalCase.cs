using SuitsApp.Domain.Common;

namespace SuitsApp.Domain.Entities;
public class LegalCase : BaseEntity
{
    public DateTime StartDate { get; set; }
    public float SuccessRate { get; set; }
    public ICollection<Document>? Documents { get; set; }
    public Lawyer? Lawyer { get; set; }
    public Client? Client { get; set; }
}
