namespace ResTIConnect.Aplication.InputModels;
public class NewEventoInputModel
{
    public required string Tipo { get; set; }
    public required string Descricao { get; set; }
    public required string Codigo { get; set; }
    public required string Conteudo { get; set; }
    public required DateTimeOffset DataHoraOcorrencia { get; set; }
}
