using TechMed.Infrastructure.Persistence;

namespace TechMed.Application;

public abstract class BaseService
{
    public readonly TechMedDbContext _context;
    protected BaseService(TechMedDbContext context){
        _context = context;
    }
}
