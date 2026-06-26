using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentNodePollRequest
{
	[JsonPropertyName("timeoutMs")]
	public int TimeoutMs { get; set; } = 25000;

	[JsonPropertyName("capabilities")]
	public Dictionary<string, JsonElement>? Capabilities { get; set; }
}
