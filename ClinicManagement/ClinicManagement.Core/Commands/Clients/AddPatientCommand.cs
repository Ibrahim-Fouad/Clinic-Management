using System.Text.Json.Serialization;
using ClinicManagement.Core.DTOs.Clients;
using ClinicManagement.Core.Enums;
using ClinicManagement.Core.ValueObjects;
using MediatR;

namespace ClinicManagement.Core.Commands.Clients;

public record AddPatientCommand
([property: JsonIgnore] int ClientId, string Name, Sex Sex, AnimalType AnimalType,
    int? PreferredDoctorId) : IRequest<ClientDto?>;