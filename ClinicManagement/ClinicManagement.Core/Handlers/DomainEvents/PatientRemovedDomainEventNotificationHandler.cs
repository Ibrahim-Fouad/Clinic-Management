using ClinicManagement.Core.DomainEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClinicManagement.Core.Handlers.DomainEvents;

internal sealed class PatientRemovedDomainEventNotificationHandler : INotificationHandler<PatientRemovedDomainEvent>
{
    private readonly ILogger<PatientRemovedDomainEventNotificationHandler> _logger;

    public PatientRemovedDomainEventNotificationHandler(ILogger<PatientRemovedDomainEventNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(PatientRemovedDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            $"Patient called '{notification.Patient.Name}' has been removed from client '{notification.ClientName}' with client id: {notification.ClientId}");
        return Task.CompletedTask;
    }
}