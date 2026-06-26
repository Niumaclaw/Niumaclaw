using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentNodeRegisterRequest
{
	[JsonPropertyName("deviceId")]
	public string? DeviceId { get; set; }

	[JsonPropertyName("deviceName")]
	public string? DeviceName { get; set; }

	[JsonPropertyName("platform")]
	public string? Platform { get; set; }

	[JsonPropertyName("version")]
	public string? Version { get; set; }

	[JsonPropertyName("capabilities")]
	public Dictionary<string, JsonElement>? Capabilities { get; set; }
}
