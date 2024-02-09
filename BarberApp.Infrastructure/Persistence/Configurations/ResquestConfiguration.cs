using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BarberApp.Domain.Entities;

namespace BarberApp.Infrastructure.Persistence.Configuration;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder
        .ToTable("Requests")
        .HasKey(e => e.RequestId);

    }
}