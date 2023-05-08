using ClinicManagement.Core.DTOs;
using ClinicManagement.Core.DTOs.Doctors;
using MediatR;

namespace ClinicManagement.Core.Queries.Doctors;

public record ListDoctorsQuery(string? Name, int PageSize = 10, int PageNumber = 1) : IRequest<Paged<DoctorDto>>;