using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentNodeBindRequest
{
	[JsonPropertyName("employeeName")]
	public string? EmployeeName { get; set; }

	[JsonPropertyName("nodeId")]
	public long NodeId { get; set; }

	[JsonPropertyName("adapterType")]
	public string? AdapterType { get; set; }

	[JsonPropertyName("workspacePath")]
	public string? WorkspacePath { get; set; }

	[JsonPropertyName("adapterConfig")]
	public Dictionary<string, JsonElement>? AdapterConfig { get; set; }
}
