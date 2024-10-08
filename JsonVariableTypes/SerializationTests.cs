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
    public void DeserializesNumericValue()
    {
        var json = /*lang=json,strict*/
            """{"Version":1}""";

        var appInfo = JsonSerializer.Deserialize<AppInfo>(json);

        appInfo!.Version.Should().Be("1");
    }

    [Test]
    public void SerializedStringValue()
    {
        var appInfo = new AppInfo { Version = "1.0.0" };

        var json = JsonSerializer.Serialize(appInfo);

        json.Should()
            .Be( /*lang=json,strict*/
                """{"Version":"1.0.0"}"""
            );
    }

    [Test]
    public void SerializedNumericValue()
    {
        var appInfo = new AppInfo { Version = "1" };

        var json = JsonSerializer.Serialize(appInfo);

        json.Should()
            .Be( /*lang=json,strict*/
                """{"Version":1}"""
            );
    }
}
