using ClinicManagement.Core.Aggregates;
using ClinicManagement.Core.Commands.Clients;
using ClinicManagement.Core.DTOs.Clients;
using ClinicManagement.Core.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Handlers.Commands.Clients;

internal sealed class RemovePatientCommandHandler : IRequestHandler<RemovePatientCommand, ClientDto?>
{
    private readonly IAppDbContext _dbContext;

    public RemovePatientCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ClientDto?> Handle(RemovePatientCommand request, CancellationToken cancellationToken)
    {
        var client = await _dbContext.Clients
            .Include(p => p.PreferredDoctor)
            .Include(p => p.Patients)
            .FirstOrDefaultAsync(p => p.Id == request.ClientId, cancellationToken);

        if (client is null)
            throw new Exception("Client is not found");

        var patient = client.Patients.FirstOrDefault(p => p.Id == request.PatientId);
        if(patient is null)
            throw new Exception("Patient is not found");

        client.RemovePatient(patient);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return client.Adapt<ClientDto>();
    }
}