namespace ResTIConnect.Aplication.InputModels;

public class NewSistemaInputModel
{
    public int SistemaId { get; set; }
    public required string Descricao { get; set; }
    public required string Tipo { get; set; }
    public required string EnderecoEntrada { get; set; }
    public required string EnderecoSaida { get; set; }
    public required string Protocolo { get; set; }
    public required DateTimeOffset DataHoraOcorrencia { get; set; }
    public required string Status { get; set; }
}
