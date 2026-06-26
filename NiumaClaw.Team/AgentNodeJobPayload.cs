using System.Text.Json;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentNodeJobPayload
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("accountId")]
	public string AccountId { get; set; } = "";

	[JsonPropertyName("employeeName")]
	public string EmployeeName { get; set; } = "";

	[JsonPropertyName("adapterType")]
	public string AdapterType { get; set; } = "";

	[JsonPropertyName("prompt")]
	public string Prompt { get; set; } = "";

	[JsonPropertyName("payload")]
	public JsonElement Payload { get; set; }

	[JsonPropertyName("boardTaskId")]
	public string? BoardTaskId { get; set; }

	[JsonPropertyName("createdAt")]
	public string CreatedAt { get; set; } = "";
}
