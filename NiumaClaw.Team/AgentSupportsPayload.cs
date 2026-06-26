using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentSupportsPayload
{
	[JsonPropertyName("approvals")]
	public bool Approvals { get; set; }

	[JsonPropertyName("runs")]
	public bool Runs { get; set; }

	[JsonPropertyName("history")]
	public bool History { get; set; }

	[JsonPropertyName("attachments")]
	public bool Attachments { get; set; }

	[JsonPropertyName("vision")]
	public bool Vision { get; set; }
}
