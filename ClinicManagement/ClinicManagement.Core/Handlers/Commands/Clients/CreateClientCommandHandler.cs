using ClinicManagement.Core.Aggregates;
using ClinicManagement.Core.Commands.Clients;
using ClinicManagement.Core.DTOs.Clients;
using ClinicManagement.Core.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Handlers.Commands.Clients;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ClientDto>
{
    private readonly IAppDbContext _dbContext;

    public CreateClientCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ClientDto> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        if (await _dbContext.Clients.AnyAsync(x => x.EmailAddress == request.EmailAddress, cancellationToken))
            throw new Exception("Email address is already exists.");

        var client = request.Adapt<Client>();
        _dbContext.Clients.Add(client);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return client.Adapt<ClientDto>();
    }
}