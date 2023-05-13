using ClinicManagement.Core.Aggregates;
using ClinicManagement.Core.DTOs;
using ClinicManagement.Core.DTOs.Clients;
using ClinicManagement.Core.Extensions;
using ClinicManagement.Core.Interfaces;
using ClinicManagement.Core.Queries.Clients;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Handlers.Queries.Clients;

internal sealed class ListClientsQueryHandler : IRequestHandler<ListClientQuery, Paged<ClientDto>>
{
    private readonly IAppDbContext _dbContext;

    public ListClientsQueryHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Paged<ClientDto>> Handle(ListClientQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Clients.AsNoTracking()
            .WhereIf(!string.IsNullOrWhiteSpace(request.Name),
                client => client.FullName.Contains(request.Name!) ||
                          client.PreferredName.Contains(request.Name!))
            .OrderBy(c => c.Id)
            .PageAsync<Client, ClientDto>(request.PageNumber, request.PageSize, cancellationToken);
    }
}