using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.Core.DTOs.Doctors;
using MediatR;

namespace ClinicManagement.Core.Commands.Doctors;

public record CreateDoctorCommand(string Name) : IRequest<DoctorDto>;
