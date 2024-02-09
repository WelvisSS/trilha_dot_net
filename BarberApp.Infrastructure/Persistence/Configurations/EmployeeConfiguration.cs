using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BarberApp.Domain.Entities;

namespace BarberApp.Infrastructure.Persistence.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
        .ToTable("Employees")
        .HasKey(e => e.EmployeeId);

    }
}