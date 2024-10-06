using System.Text.Json;
using FluentAssertions;

namespace JsonVariableTypes;

public class SerializationTests
{
    [Test]
    public void DeserializesStringValue()
    {
        var json = /*lang=json,strict*/
            """{"Version":"1.0.0"}""";

        var appInfo = JsonSerializer.Deserialize<AppInfo>(json);

        appInfo!.Version.Should().Be("1.0.0");
    }

    [Test]
    public void FailsToDeserializeNumericValue()
    {
        var json = /*lang=json,strict*/
            """{"Version":1}""";

        var action = () => JsonSerializer.Deserialize<AppInfo>(json);

        action
            .Should()
            .Throw<JsonException>()
            .WithMessage(
                "The JSON value could not be converted to System.String. Path: $.Version | LineNumber: 0 | BytePositionInLine: 12."
            );
    }
}
