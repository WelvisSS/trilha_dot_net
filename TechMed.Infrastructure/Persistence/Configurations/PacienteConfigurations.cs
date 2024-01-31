using Microsoft.EntityFrameworkCore;
using TechMed.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TechMed.Infrastructure.Persistence.Configurations;

public class PacienteConfigurations : IEntityTypeConfiguration<Paciente>
{
   public void Configure(EntityTypeBuilder<Paciente> builder)
   {
      //configurações de mapeamento da entidade Paciente
      builder
         .ToTable("Pacientes")
         .HasKey(m => m.PacienteId);
   }
}