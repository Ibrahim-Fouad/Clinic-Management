using ClinicManagement.Core.DTOs.Doctors;
using MediatR;

namespace ClinicManagement.Core.Commands.Doctors;

public record UpdateDoctorCommand(int Id, string Name) : IRequest<DoctorDto>;