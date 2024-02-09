using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BarberApp.Domain.Entities;

namespace BarberApp.Infrastructure.Persistence.Configuration;

public class PhysicalPersonConfiguration : IEntityTypeConfiguration<PhysicalPerson>
{
    public void Configure(EntityTypeBuilder<PhysicalPerson> builder)
    {
        builder
        .ToTable("PhysicalPersons")
        .HasKey(e => e.PersonId);

    }
}