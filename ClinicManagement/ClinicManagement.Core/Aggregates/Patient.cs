using ClinicManagement.Core.Enums;
using ClinicManagement.Core.ValueObjects;
using VetClinic.SharedKernel;

namespace ClinicManagement.Core.Aggregates;

public class Patient : Entity<int>
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public Sex Sex { get; set; }
    public AnimalType AnimalType { get; set; }
    public int? PreferredDoctorId { get; set; }
    public Doctor? PreferredDoctor { get; set; }

    private Patient() : base(0)
    {
    }

    internal Patient(int clientId, string name, Sex sex, AnimalType animalType, int? preferredDoctorId) : base(0)
    {
        ClientId = clientId;
        Name = name;
        Sex = sex;
        AnimalType = animalType;
        PreferredDoctorId = preferredDoctorId;
    }

    public override string ToString() => Name;
}