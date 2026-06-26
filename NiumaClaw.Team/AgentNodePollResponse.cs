using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentNodePollResponse
{
	[JsonPropertyName("job")]
	public AgentNodeJobPayload? Job { get; set; }
}
