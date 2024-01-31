using Microsoft.EntityFrameworkCore;
using TechMed.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TechMed.Infrastructure.Persistence.Configurations;

public class MedicoConfigurations : IEntityTypeConfiguration<Medico>
{
   public void Configure(EntityTypeBuilder<Medico> builder)
   {
      //configurações de mapeamento da entidade Medico
      builder
         .ToTable("Medicos")
         .HasKey(m => m.MedicoId);
   }
}