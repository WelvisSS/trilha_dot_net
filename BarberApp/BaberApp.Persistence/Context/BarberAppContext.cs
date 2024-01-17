using BarberApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberApp.Persistence.Context;

public class BarberAppContext : DbContext
{
    public DbSet<Client> Client { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<LegalPerson> LegalPersons { get; set; }
    public DbSet<PhysicalPerson> PhysicalPersons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=dotnet;password=tic2023;database=barberdb";
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Client>().ToTable("Clients").HasKey(m => m.ClientId);
        modelBuilder.Entity<Person>().ToTable("Persons").HasKey(p => p.PersonId);
        modelBuilder.Entity<Employee>().ToTable("Employeess").HasKey(a => a.EmployeeId);
        modelBuilder.Entity<LegalPerson>().ToTable("LegalPersons").HasKey(a => a.LegalPersonId);
        modelBuilder.Entity<PhysicalPerson>().ToTable("PhysicalPersonss").HasKey(a => a.PhysicalPersonId);

        modelBuilder.Entity<LegalPerson>()
            .HasOne(a => a.Person)
            .WithOne(p => p.LegalPerson)
            .HasForeignKey<Person>(a => a.PersonId);

        modelBuilder.Entity<PhysicalPerson>()
            .HasOne(a => a.Person)
            .WithOne(p => p.PhysicalPerson)
            .HasForeignKey<Person>(a => a.PersonId);

        modelBuilder.Entity<Client>()
            .HasOne(a => a.Person)
            .WithOne(p => p.Client)
            .HasForeignKey<Person>(a => a.PersonId);

        modelBuilder.Entity<Employee>()
            .HasOne(a => a.Person)
            .WithOne(p => p.Employee)
            .HasForeignKey<Person>(a => a.PersonId);

    }
}

