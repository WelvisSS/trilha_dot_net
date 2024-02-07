using ResTIConnect.Infrastructure;

namespace ResTIConnect.Aplication;

public abstract class BaseService
{
    protected readonly IResTIConnectContext _context;
    protected BaseService(IResTIConnectContext context)
    {
        _context = context;
    }
}
