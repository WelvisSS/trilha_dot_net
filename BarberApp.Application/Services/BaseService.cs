using BarberApp.Infrastructure.Persistence;

namespace BarberApp.Application.Services;

public abstract class BaseService
{
    public readonly BarberAppDbContext _context;
    protected BaseService(BarberAppDbContext context)
    {
        _context = context;
    }
}
