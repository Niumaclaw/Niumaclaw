using System.Text.Json;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentRunPayload
{
	[JsonPropertyName("runId")]
	public string RunId { get; set; } = string.Empty;

	[JsonPropertyName("user")]
	public string User { get; set; } = string.Empty;

	[JsonPropertyName("role")]
	public string Role { get; set; } = string.Empty;

	[JsonPropertyName("taskText")]
	public string TaskText { get; set; } = string.Empty;

	[JsonPropertyName("status")]
	public string Status { get; set; } = string.Empty;

	[JsonPropertyName("origin")]
	public string Origin { get; set; } = string.Empty;

	[JsonPropertyName("workspace")]
	public string Workspace { get; set; } = string.Empty;

	[JsonPropertyName("createdAt")]
	public string CreatedAt { get; set; } = string.Empty;

	[JsonPropertyName("updatedAt")]
	public string UpdatedAt { get; set; } = string.Empty;

	[JsonPropertyName("finalContent")]
	public string FinalContent { get; set; } = string.Empty;

	[JsonPropertyName("lastError")]
	public string LastError { get; set; } = string.Empty;

	[JsonPropertyName("provider")]
	public string Provider { get; set; } = string.Empty;

	[JsonPropertyName("model")]
	public string Model { get; set; } = string.Empty;

	[JsonPropertyName("inputTokens")]
	public int InputTokens { get; set; }

	[JsonPropertyName("outputTokens")]
	public int OutputTokens { get; set; }

	[JsonPropertyName("estimatedCost")]
	public decimal EstimatedCost { get; set; }

	[JsonPropertyName("costCurrency")]
	public string CostCurrency { get; set; } = string.Empty;

	[JsonPropertyName("taskId")]
	public string TaskId { get; set; } = string.Empty;

	[JsonPropertyName("steps")]
	public JsonElement Steps { get; set; }

	[JsonPropertyName("artifacts")]
	public JsonElement Artifacts { get; set; }

	[JsonPropertyName("pendingApproval")]
	public JsonElement PendingApproval { get; set; }

	[JsonPropertyName("adapterType")]
	public string AdapterType { get; set; } = string.Empty;
}
