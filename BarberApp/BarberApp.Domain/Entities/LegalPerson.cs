namespace BarberApp.Domain.Entities;
public class LegalPerson
{
    public required int LegalPersonId { get; set; }
    public required Person Person { get; set; }
    public required string CNPJ { get; set; }
}
