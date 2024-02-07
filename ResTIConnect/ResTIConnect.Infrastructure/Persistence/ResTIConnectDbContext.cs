using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;
namespace ResTIConnect.Infrastructure;

public class ResTIConnectDbContext : DbContext
{
    public DbSet<Perfis> Perfis { get; set; }
    public ResTIConnectDbContext(DbContextOptions<ResTIConnectDbContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResTIConnectDbContext).Assembly);
    }
}

