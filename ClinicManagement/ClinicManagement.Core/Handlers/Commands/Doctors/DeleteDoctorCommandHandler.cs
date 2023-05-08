using ClinicManagement.Core.Commands.Doctors;
using ClinicManagement.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Handlers.Commands.Doctors;

internal sealed class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
{
    private readonly IAppDbContext _dbContext;

    public DeleteDoctorCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Doctors.Where(p => p.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);

        if (result < 1)
            throw new Exception("Error deleting, Doctor may not be exists.");
    }
}