using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentJobRecord
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("accountId")]
	public Guid AccountId { get; set; }

	[JsonPropertyName("nodeId")]
	public long NodeId { get; set; }

	[JsonPropertyName("employeeName")]
	public string EmployeeName { get; set; } = "";

	[JsonPropertyName("adapterType")]
	public string AdapterType { get; set; } = "";

	[JsonPropertyName("status")]
	public string Status { get; set; } = "queued";

	[JsonPropertyName("prompt")]
	public string Prompt { get; set; } = "";

	[JsonPropertyName("payload")]
	public JsonElement Payload { get; set; }

	[JsonPropertyName("result")]
	public string? Result { get; set; }

	[JsonPropertyName("error")]
	public string? Error { get; set; }

	[JsonPropertyName("boardTaskId")]
	public string? BoardTaskId { get; set; }

	[JsonPropertyName("createdAt")]
	public string? CreatedAt { get; set; }

	[JsonPropertyName("startedAt")]
	public string? StartedAt { get; set; }

	[JsonPropertyName("finishedAt")]
	public string? FinishedAt { get; set; }

	[JsonPropertyName("updatedAt")]
	public string? UpdatedAt { get; set; }
}
