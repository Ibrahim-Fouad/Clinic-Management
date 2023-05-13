using ClinicManagement.Core.Commands.Clients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers;

[Route("clients/{clientId}/patients")]
public class PatientsController : BaseApiController
{
    private readonly ISender _sender;

    public PatientsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> AddPatient(int clientId, AddPatientCommand patientCommand,
        CancellationToken cancellationToken = default)
    {
        var command = patientCommand with { ClientId = clientId };
        return Ok(await _sender.Send(command, cancellationToken));
    }


    [HttpDelete("{patientId}")]
    public async Task<IActionResult> RemovePatient(int clientId, int patientId,
        CancellationToken cancellationToken = default)
    {
        var command = new RemovePatientCommand(clientId, patientId);
        return Ok(await _sender.Send(command, cancellationToken));
    }


}