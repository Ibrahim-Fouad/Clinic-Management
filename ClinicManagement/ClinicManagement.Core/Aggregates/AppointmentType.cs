using VetClinic.SharedKernel;

namespace ClinicManagement.Core.Aggregates;

public class AppointmentType : Entity<int>
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    public int Duration { get; private set; }

    internal AppointmentType(string name, string code, int duration) : base(0)
    {
        Name = name;
        Code = code;
        Duration = duration;
    }

    public override string ToString() => Name;
}