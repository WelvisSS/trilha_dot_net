using Microsoft.EntityFrameworkCore;
namespace ResTIConnect.Infrastructure;

public class ResTIConnectDbContext : DbContext
{
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

