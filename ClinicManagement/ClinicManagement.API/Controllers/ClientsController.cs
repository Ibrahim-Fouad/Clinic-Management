﻿using ClinicManagement.Core.Commands.Clients;
using ClinicManagement.Core.Queries.Clients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers;

public class ClientsController : BaseApiController
{
    private readonly IMediator _mediator;

    public ClientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateClientCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] ListClientQuery request, CancellationToken cancellationToken)
    {
        return Ok(
            await _mediator.Send(request, cancellationToken)
        );
    }
}