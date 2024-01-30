using Microsoft.EntityFrameworkCore;
using SuitsApp.Domain.Entities;

namespace SuitsApp.Infra.Persistence;
public class SuisAppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<LegalCase> LegalCases { get; set; }
    public DbSet<Lawyer> Lawyers { get; set; }
    public DbSet<Document> Documents { get; set; }

    public SuisAppDbContext(DbContextOptions<SuisAppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SuisAppDbContext).Assembly);
    }

}
