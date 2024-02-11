using BarberApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberApp.Infrastructure.Persistence.Context;

public class BarberAppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<LegalPerson> LegalPersons { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<PhysicalPerson> PhysicalPersons { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Request> Requests { get; set; }


    public BarberAppDbContext(DbContextOptions<BarberAppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BarberAppDbContext).Assembly);
    }
}
