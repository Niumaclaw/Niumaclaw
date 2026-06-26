using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentHealthPayload
{
	[JsonPropertyName("status")]
	public string Status { get; set; } = "unknown";

	[JsonPropertyName("source")]
	public string Source { get; set; } = string.Empty;

	[JsonPropertyName("message")]
	public string Message { get; set; } = string.Empty;

	[JsonPropertyName("lastSeenAt")]
	public string LastSeenAt { get; set; } = string.Empty;
}
