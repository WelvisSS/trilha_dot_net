namespace ResTIConnect.Domain.Entities;

public class Enderecos
{
    public int EnderecoId { get; set; }

    public required string Logradouro { get; set; }

    public required string Numero { get; set; }

    public required string Cidade { get; set; }

    public string? Complemento { get; set; }

    public required string Cep { get; set; }

    public required string Bairro { get; set; }

    public required string Estado { get; set; }

    public required string Pais { get; set; }

    // public int UserId;
    public User? User {get; set;}


}
