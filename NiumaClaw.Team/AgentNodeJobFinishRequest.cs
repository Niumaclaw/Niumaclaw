using System.Text.Json;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentNodeJobFinishRequest
{
	[JsonPropertyName("ok")]
	public bool Ok { get; set; }

	[JsonPropertyName("output")]
	public string? Output { get; set; }

	[JsonPropertyName("error")]
	public string? Error { get; set; }

	[JsonPropertyName("metadata")]
	public JsonElement? Metadata { get; set; }
}
