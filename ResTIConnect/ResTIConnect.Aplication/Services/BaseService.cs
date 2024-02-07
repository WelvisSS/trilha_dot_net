using ResTIConnect.Infrastructure.Persistence;
namespace ResTIConnect.Aplication;

public abstract class BaseService
{
    protected readonly ResTIConnectDbContext _context;
    protected BaseService(ResTIConnectDbContext context)
    {
        _context = context;
    }
}
