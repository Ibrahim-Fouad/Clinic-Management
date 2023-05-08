using VetClinic.SharedKernel;

namespace ClinicManagement.Core.Aggregates;

public class Room : Entity<int>
{
    public string Name { get; private set; }

    public Room(string name) : base(0)
    {
        Name = name;
    }

    public override string ToString() => Name;
}