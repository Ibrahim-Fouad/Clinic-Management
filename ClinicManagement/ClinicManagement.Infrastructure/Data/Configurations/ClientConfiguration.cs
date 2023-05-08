using ClinicManagement.Core.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Property(p => p.FullName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.PreferredName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(p => p.EmailAddress)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(p => p.EmailAddress)
            .IsUnique();

    }
}