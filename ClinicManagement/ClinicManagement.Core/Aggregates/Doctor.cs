using VetClinic.SharedKernel;

namespace ClinicManagement.Core.Aggregates;

public class Doctor : Entity<int>
{
    public string Name { get; private set; }

    public Doctor(string name) : base(0)
    {
        Name = name;
    }

    public override string ToString() => Name;

    public void ChangeName(string newName)
    {
        if (Name.Equals(newName, StringComparison.OrdinalIgnoreCase))
            return;

        Name = newName;
    }
}