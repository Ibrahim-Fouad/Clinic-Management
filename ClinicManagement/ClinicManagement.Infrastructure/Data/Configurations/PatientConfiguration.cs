using ClinicManagement.Core.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.Data.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Sex)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(7);

        builder
            .OwnsOne(p => p.AnimalType, p =>
            {
                p.Property(pp => pp.Breed).HasColumnName("AnimalType_Breed").HasMaxLength(50);
                p.Property(pp => pp.Species).HasColumnName("AnimalType_Species").HasMaxLength(50);
            });
    }
}