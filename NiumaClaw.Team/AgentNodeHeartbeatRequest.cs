using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentNodeHeartbeatRequest
{
	[JsonPropertyName("platform")]
	public string? Platform { get; set; }

	[JsonPropertyName("version")]
	public string? Version { get; set; }

	[JsonPropertyName("capabilities")]
	public Dictionary<string, JsonElement>? Capabilities { get; set; }
}
