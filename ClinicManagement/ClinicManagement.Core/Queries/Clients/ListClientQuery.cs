using ClinicManagement.Core.DTOs;
using ClinicManagement.Core.DTOs.Clients;
using MediatR;

namespace ClinicManagement.Core.Queries.Clients;

public record ListClientQuery(string? Name, int PageSize = 10, int PageNumber = 1) : IRequest<Paged<ClientDto>>;