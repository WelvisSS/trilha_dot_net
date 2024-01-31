using Microsoft.EntityFrameworkCore;
using TechMed.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;




namespace TechMed.Infrastructure.Persistence.Configurations;
public class AtendimentoConfigurations : IEntityTypeConfiguration<Atendimento>
{
    public void Configure(EntityTypeBuilder<Atendimento> builder)
    {
        //configurações de mapeamento da entidade Atendimento
        builder
           .ToTable("Atendimentos")
           .HasKey(m => m.AtendimentoId);

        builder
           .HasOne(m => m.Medico)
           .WithMany(m => m.Atendimentos)
           .HasForeignKey(m => m.MedicoId);

        builder
           .HasOne(m => m.Paciente)
           .WithMany(m => m.Atendimentos)
           .HasForeignKey(m => m.PacienteId);
    }
}
