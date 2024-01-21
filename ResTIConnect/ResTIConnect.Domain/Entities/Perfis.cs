namespace ResTIConnect.Domain.Entities;

public class Perfis
{
    public required int PerfilId { get; set; }

    public required string Descricao { get; set; }

    public required string Permissoes { get; set; }

    public int UsuarioId {get; set;}
    public User User {get; set;}
    // public ICollection<User>? Users { get; set; }
}
