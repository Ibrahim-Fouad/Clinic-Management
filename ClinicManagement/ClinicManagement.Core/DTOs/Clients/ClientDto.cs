using ClinicManagement.Core.DTOs.Patients;

namespace ClinicManagement.Core.DTOs.Clients;

public record ClientDto(string FullName,
    string EmailAddress,
    string PreferredName,
    string PreferredDoctorName,
    IEnumerable<PatientDto> Patients);