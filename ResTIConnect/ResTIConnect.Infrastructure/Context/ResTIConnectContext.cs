using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure.Context;
public class ResTIConnectContext : DbContext
{
    public DbSet<Log> Logs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Perfis> Perfis { get; set; }
    public DbSet<Enderecos> Enderecos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=root;password=432747;database=resticonnect";
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Log>().ToTable("Logs").HasKey(m => m.LogId);
        modelBuilder.Entity<User>().ToTable("Users").HasKey(m => m.UsuarioId);
        modelBuilder.Entity<Perfis>().ToTable("Perfis").HasKey(m => m.PerfilId);
        modelBuilder.Entity<Enderecos>().ToTable("Enderecos").HasKey(m => m.EnderecoId);

        modelBuilder.Entity<Enderecos>()
            .HasOne(a => a.User)
            .WithOne(p => p.Endereco)
            .HasForeignKey<User>(a => a.UsuarioId);

        modelBuilder.Entity<Perfis>()
            .HasOne(a => a.User)
            .WithMany(m => m.Perfis)
            .HasForeignKey(a => a.UsuarioId);
    }
}
