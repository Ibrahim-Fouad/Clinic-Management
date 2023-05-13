using ClinicManagement.Core.Aggregates;
using ClinicManagement.Core.Commands.Clients;
using ClinicManagement.Core.DomainEvents;
using ClinicManagement.Core.DTOs.Clients;
using ClinicManagement.Core.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Handlers.Commands.Clients;

internal sealed class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, ClientDto?>
{
    private readonly IAppDbContext _dbContext;

    public AddPatientCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ClientDto?> Handle(AddPatientCommand request, CancellationToken cancellationToken)
    {
        var client = await _dbContext.Clients
            .Include(p => p.PreferredDoctor)
            .Include(p => p.Patients)
            .FirstOrDefaultAsync(p => p.Id == request.ClientId, cancellationToken);

        if (client is null)
            throw new Exception("Client is not found");

        var patient = request.Adapt<Patient>();

        client.AddPatient(patient);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return client.Adapt<ClientDto>();
    }
}