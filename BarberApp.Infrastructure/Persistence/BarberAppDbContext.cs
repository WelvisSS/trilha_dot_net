using BarberApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TechMed.Infrastructure.Persistence;
public class BarberAppDbContext : DbContext
{
    public DbSet<Request> Requests { get; set; }

    public BarberAppDbContext(DbContextOptions<BarberAppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BarberAppDbContext).Assembly);
    }
}
