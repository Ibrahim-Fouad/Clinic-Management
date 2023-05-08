using ClinicManagement.Core.Aggregates;
using ClinicManagement.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using VetClinic.SharedKernel;

namespace ClinicManagement.Infrastructure.Data;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; } = default!;
    public DbSet<AppointmentType> AppointmentTypes { get; set; } = default!;
    public DbSet<Patient> Patients { get; set; } = default!;
    public DbSet<Room> Rooms { get; set; } = default!;
    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var model in modelBuilder.Model.GetEntityTypes().Where(p => p.BaseType?.ClrType == typeof(Entity<>)))
        {
            modelBuilder.Entity(model.ClrType)
                .HasKey(nameof(Entity<object>.Id));
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}