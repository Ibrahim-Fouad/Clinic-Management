using ClinicManagement.Core.DomainEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClinicManagement.Core.Handlers.DomainEvents;

internal sealed class PatientAddedDomainEventNotificationHandler : INotificationHandler<PatientAddedDomainEvent>
{
    private readonly ILogger<PatientAddedDomainEventNotificationHandler> _logger;

    public PatientAddedDomainEventNotificationHandler(ILogger<PatientAddedDomainEventNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(PatientAddedDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            $"New patient called '{notification.Patient.Name}' has been added to client '{notification.ClientName}' with client id: {notification.ClientId}");
        return Task.CompletedTask;
    }
}