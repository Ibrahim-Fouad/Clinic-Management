using ClinicManagement.Core.Commands.Doctors;
using ClinicManagement.Core.DTOs.Doctors;
using ClinicManagement.Core.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Handlers.Commands.Doctors;

internal sealed class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, DoctorDto>
{
    private readonly IAppDbContext _dbContext;

    public UpdateDoctorCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DoctorDto> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        if (await _dbContext.Doctors.AnyAsync(d => d.Name == request.Name && d.Id != request.Id, cancellationToken))
            throw new Exception("New name is already exists");

        var doctor = await _dbContext.Doctors.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (doctor is null)
            throw new Exception("Doctor is not found");

        doctor.ChangeName(request.Name);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return doctor.Adapt<DoctorDto>();
    }
}