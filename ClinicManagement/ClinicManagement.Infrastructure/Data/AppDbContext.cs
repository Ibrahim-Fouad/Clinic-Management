using ClinicManagement.Core.Aggregates;
using ClinicManagement.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VetClinic.SharedKernel;

namespace ClinicManagement.Infrastructure.Data;

public class AppDbContext : DbContext, IAppDbContext
{
    private readonly IMediator _mediator;

    public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
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

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        var entries = ChangeTracker.Entries()
            .Select(t => t.Entity as Entity<int>)
            .Where(e => e?.DomainEvent is not null && e.DomainEvent.Any())
            .ToArray();

        entries ??= Array.Empty<Entity<int>>();


        foreach (var entity in entries)
        {
            var events = entity!.DomainEvent.ToArray();
            entity.DomainEvent.Clear();
            foreach (var @event in events)
            {
                await _mediator.Publish(@event, cancellationToken);
            }
        }

        return result;
    }
}