using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BarberApp.Domain.Entities;

namespace BarberApp.Infrastructure.Persistence.Configuration;

public class LegalPersonConfiguration : IEntityTypeConfiguration<LegalPerson>
{
    public void Configure(EntityTypeBuilder<LegalPerson> builder)
    {
        builder
        .ToTable("LegalPersons")
        .HasKey(e => e.PersonId);

    }
}