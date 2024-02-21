using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure.Persistence.Configurations;

public class SistemaConfiguration : IEntityTypeConfiguration<Sistemas>
{
    public void Configure(EntityTypeBuilder<Sistemas> builder)
    {
        builder
            .ToTable("Sistemas")
            .HasKey(e => e.SistemaId);

    }
}
