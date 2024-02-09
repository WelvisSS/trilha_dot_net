namespace BarberApp.Application;

public abstract class BaseService
{
    public readonly BarberAppDbContext _context;
    protected BaseService(BarberAppDbContext context)
    {
        _context = context;
    }
}
