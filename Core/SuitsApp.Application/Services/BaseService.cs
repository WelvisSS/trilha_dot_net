using SuitsApp.Infra.Persistence;

namespace SuitsApp.Application.Services;
public abstract class BaseService
{
    protected readonly SuisAppDbContext _context;
    protected BaseService(SuisAppDbContext context){
        _context = context;
    }
}
