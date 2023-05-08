﻿using VetClinic.SharedKernel;

namespace ClinicManagement.Core.Aggregates;

public class Client : Entity<int>
{
    public string FullName { get; private set; }
    public string PreferredName { get; private set; }
    public string EmailAddress { get; private set; }
    public int PreferredDoctorId { get; private set; }
    public Doctor PreferredDoctor { get; set; } = null!;

    private readonly IList<Patient> _patients = new List<Patient>();
    public IList<Patient> Patients => _patients.AsReadOnly();

    internal Client(string fullName, string preferredName, string emailAddress, int preferredDoctorId) : base(0)
    {
        FullName = fullName;
        PreferredName = preferredName;
        EmailAddress = emailAddress;
        PreferredDoctorId = preferredDoctorId;
    }


    public void AddPatient(Patient patient)
    {
        if (_patients.Contains(patient))
            return;

        _patients.Add(patient);
    }

    public override string ToString() => $"{FullName} ({PreferredName})";
}