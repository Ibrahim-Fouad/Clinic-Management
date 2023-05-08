using ClinicManagement.Core.Commands.Clients;
using ClinicManagement.Core.Commands.Doctors;
using ClinicManagement.Core.Queries.Doctors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers;

public class DoctorsController : BaseApiController
{
    private readonly IMediator _mediator;

    public DoctorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request with { Id = id }, cancellationToken));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteDoctorCommand(id), cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] ListDoctorsQuery query, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(query, cancellationToken));
    }
}