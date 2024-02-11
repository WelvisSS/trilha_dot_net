using BarberApp.Infrastructure.Persistence.Context;

namespace BarberApp.Application.Services;

public abstract class BaseService
{
    public readonly BarberAppDbContext _context;
    protected BaseService(BarberAppDbContext context)
    {
        _context = context;
    }
}
