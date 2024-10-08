using System.Text.Json.Serialization;

namespace JsonVariableTypes;

internal class AppInfo
{
    [JsonConverter(typeof(NumericStringAsNumberJsonConverter))]
    public string? Version { get; set; }
}
