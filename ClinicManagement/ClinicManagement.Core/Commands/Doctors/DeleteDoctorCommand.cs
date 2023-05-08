using MediatR;

namespace ClinicManagement.Core.Commands.Doctors;

public record DeleteDoctorCommand(int Id) : IRequest;