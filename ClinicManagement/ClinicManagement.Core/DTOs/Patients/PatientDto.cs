using ClinicManagement.Core.Enums;
using ClinicManagement.Core.ValueObjects;

namespace ClinicManagement.Core.DTOs.Patients;

public record PatientDto(string Name, Sex Sex, AnimalType AnimalType, string? PreferredDoctorName);