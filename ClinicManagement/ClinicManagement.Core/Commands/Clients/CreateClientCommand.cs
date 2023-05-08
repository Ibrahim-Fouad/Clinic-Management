using ClinicManagement.Core.DTOs.Clients;
using MediatR;

namespace ClinicManagement.Core.Commands.Clients;

public record CreateClientCommand(string FullName, string EmailAddress, string PreferredName,
    int PreferredDoctorId) : IRequest<ClientDto>;