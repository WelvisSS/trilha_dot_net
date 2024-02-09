using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BarberApp.Domain.Entities;

namespace BarberApp.Infrastructure.Persistence.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
        .ToTable("Clients")
        .HasKey(e => e.ClientId);

    }
}