using ResTIConnect.Domain.Common;

namespace ResTIConnect.Domain.Entities;

public class User : BaseEntity
{
    public int UsuarioId { get; set; }

    public required string Nome { get; set; }

    public required string Apelido { get; set; }

    public required string Email { get; set; }

    public required string Senha { get; set; }

    public required string Telefone { get; set; }

    public int EnderecoId { get; set; }
    public required Enderecos Endereco { get; set; }
    public ICollection<Perfil>? Perfis { get; }
    public ICollection<Sistemas>? Sistemas { get; }
}
