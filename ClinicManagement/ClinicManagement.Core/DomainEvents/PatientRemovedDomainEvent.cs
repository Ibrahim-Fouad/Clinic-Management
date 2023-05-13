using ClinicManagement.Core.Aggregates;
using MediatR;
using VetClinic.SharedKernel;

namespace ClinicManagement.Core.DomainEvents;

public class PatientRemovedDomainEvent : DomainEventBase, INotification
{
    public PatientRemovedDomainEvent(int clientId, string clientName, Patient patient)
    {
        ClientId = clientId;
        Patient = patient;
        ClientName = clientName;
    }

    public int ClientId { get; }
    public string ClientName { get; }
    public Patient Patient { get; }
}