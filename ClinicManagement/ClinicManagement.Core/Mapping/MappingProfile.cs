using ClinicManagement.Core.Aggregates;
using ClinicManagement.Core.Commands.Clients;
using ClinicManagement.Core.DTOs.Clients;
using ClinicManagement.Core.DTOs.Patients;
using Mapster;

namespace ClinicManagement.Core.Mapping;

public class MappingProfile
{
    public static void Init()
    {
        TypeAdapterConfig<Client, ClientDto>
            .NewConfig()
            .Map(p => p.PreferredDoctorName, dest => dest.PreferredDoctor.Name);

        TypeAdapterConfig<CreateClientCommand, Client>
            .NewConfig()
            .ConstructUsing(p => new Client(p.FullName, p.PreferredName, p.EmailAddress, p.PreferredDoctorId));

        TypeAdapterConfig<Patient, PatientDto>
            .NewConfig()
            .Map(p => p.PreferredDoctorName, dest => (dest.PreferredDoctor!.Name), patient => patient.PreferredDoctorId.HasValue);
    }
}