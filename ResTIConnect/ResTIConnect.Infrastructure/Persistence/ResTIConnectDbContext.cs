using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure.Persistence;

public class ResTIConnectDbContext : DbContext
{
    public DbSet<Perfil> Perfis { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Eventos> Eventos { get; set; }
    public DbSet<Enderecos> Enderecos { get; set; }
    public DbSet<Sistemas> Sistemas { get; set; }

    public ResTIConnectDbContext(DbContextOptions<ResTIConnectDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResTIConnectDbContext).Assembly);
    }
}

