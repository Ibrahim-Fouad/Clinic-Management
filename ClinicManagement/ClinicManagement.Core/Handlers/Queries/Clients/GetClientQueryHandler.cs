using ClinicManagement.Core.DTOs.Clients;
using ClinicManagement.Core.Interfaces;
using ClinicManagement.Core.Queries.Clients;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Handlers.Queries.Clients;

internal sealed class GetClientQueryHandler : IRequestHandler<GetClientQuery, ClientDto?>
{
    private readonly IAppDbContext _dbContext;

    public GetClientQueryHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<ClientDto?> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Clients.AsNoTracking()
            .Where(p => p.Id == request.ClientId)
            .ProjectToType<ClientDto>()
            .FirstOrDefaultAsync(cancellationToken);
    }
}