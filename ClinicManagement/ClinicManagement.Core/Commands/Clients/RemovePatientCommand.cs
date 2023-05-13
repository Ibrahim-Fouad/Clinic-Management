using System.Text.Json.Serialization;
using ClinicManagement.Core.DTOs.Clients;
using MediatR;

namespace ClinicManagement.Core.Commands.Clients;

public record RemovePatientCommand
    (int ClientId, int PatientId) : IRequest<ClientDto?>;