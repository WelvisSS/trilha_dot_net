using BarberApp.Domain.Common;

namespace BarberApp.Domain.Entities;

public class Request : BaseEntity
{
    public int RequestId { get; set; }
    public int ClientId { get; set; }
    public DateTime? Date { get; set; }
    public double? RequiredAmount { get; set; }

}
