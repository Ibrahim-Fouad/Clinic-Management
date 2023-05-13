using ClinicManagement.Core.DTOs.Clients;
using MediatR;

namespace ClinicManagement.Core.Queries.Clients;

public record GetClientQuery(int ClientId) : IRequest<ClientDto?>;