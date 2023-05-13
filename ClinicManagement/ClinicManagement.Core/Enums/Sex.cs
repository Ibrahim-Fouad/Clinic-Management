using System.Text.Json.Serialization;

namespace ClinicManagement.Core.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))] 
public enum Sex
{
    Male,
    Female
}