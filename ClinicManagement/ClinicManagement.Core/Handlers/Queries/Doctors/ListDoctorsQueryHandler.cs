using ClinicManagement.Core.Aggregates;
using ClinicManagement.Core.DTOs;
using ClinicManagement.Core.DTOs.Doctors;
using ClinicManagement.Core.Extensions;
using ClinicManagement.Core.Interfaces;
using ClinicManagement.Core.Queries.Doctors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Handlers.Queries.Doctors;

internal sealed class ListDoctorsQueryHandler : IRequestHandler<ListDoctorsQuery, Paged<DoctorDto>>
{
    private readonly IAppDbContext _dbContext;

    public ListDoctorsQueryHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Paged<DoctorDto>> Handle(ListDoctorsQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Doctors
            .AsNoTracking()
            .WhereIf(
                !string.IsNullOrWhiteSpace(request.Name),
                p => p.Name.Contains(request.Name!))
            .OrderBy(p => p.Id)
            .PageAsync<Doctor, DoctorDto>(request.PageNumber, request.PageSize, cancellationToken);
    }
}