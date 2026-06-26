using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentNodeJobStartRequest
{
	[JsonPropertyName("message")]
	public string? Message { get; set; }
}
