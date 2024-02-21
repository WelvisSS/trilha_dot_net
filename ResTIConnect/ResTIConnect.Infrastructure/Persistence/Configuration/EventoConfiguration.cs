using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure.Persistence.Configurations;
public class EventoConfiguration : IEntityTypeConfiguration<Eventos>
{
    public void Configure(EntityTypeBuilder<Eventos> builder)
    {
        //configurações de mapeamento da entidade Atendimento
        builder
           .ToTable("Eventos")
           .HasKey(u => u.EventoId);

    }
}
