using ClinicManagement.Core.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Interfaces;

public interface IAppDbContext
{
    DbSet<Client> Clients { get; set; }
    DbSet<AppointmentType> AppointmentTypes { get; set; }
    DbSet<Patient> Patients { get; set; }
    DbSet<Room> Rooms { get; set; }
    DbSet<Doctor> Doctors { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}