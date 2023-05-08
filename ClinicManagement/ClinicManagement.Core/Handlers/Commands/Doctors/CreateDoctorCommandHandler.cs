using ClinicManagement.Core.Aggregates;
using ClinicManagement.Core.Commands.Clients;
using ClinicManagement.Core.Commands.Doctors;
using ClinicManagement.Core.DTOs.Doctors;
using ClinicManagement.Core.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Handlers.Commands.Doctors;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, DoctorDto>
{
    private readonly IAppDbContext _dbContext;

    public CreateDoctorCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DoctorDto> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        if (await _dbContext.Doctors.AnyAsync(d => d.Name == request.Name, cancellationToken))
            throw new Exception("Doctor name is already exists.");

        var doctor = new Doctor(request.Name);
        _dbContext.Doctors.Add(doctor);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return doctor.Adapt<DoctorDto>();
    }
}