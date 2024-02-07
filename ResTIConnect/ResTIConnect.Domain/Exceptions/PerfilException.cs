namespace ResTIConnect.Domain;

public class PerfilNotFoundException : Exception
{
    public PerfilNotFoundException() :
        base("Perfil não encontrado.")
    {
    }
}
