namespace ResTIConnect.Infrastructure;

public class ResTIConnectContext : IResTIConnectContext
{
    public IPerfilCollection PerfilCollection { get; } = new PerfilDB();
}
