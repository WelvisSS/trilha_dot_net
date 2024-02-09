using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure.Persistence.Configuration;

public class EnderecoConfiguration : IEntityTypeConfiguration<Enderecos>
{
    public void Configure(EntityTypeBuilder<Enderecos> builder)
    {
        builder
        .ToTable("Enderecos")
        .HasKey(e => e.EnderecoId);

    }
}
