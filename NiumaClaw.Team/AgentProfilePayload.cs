using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentProfilePayload
{
	[JsonPropertyName("user")]
	public string User { get; set; } = string.Empty;

	[JsonPropertyName("adapterType")]
	public string AdapterType { get; set; } = string.Empty;

	[JsonPropertyName("role")]
	public string Role { get; set; } = string.Empty;

	[JsonPropertyName("workspace")]
	public string Workspace { get; set; } = string.Empty;

	[JsonPropertyName("identity")]
	public string Identity { get; set; } = string.Empty;

	[JsonPropertyName("capabilities")]
	public List<string> Capabilities { get; set; } = new List<string>();

	[JsonPropertyName("supports")]
	public AgentSupportsPayload Supports { get; set; } = new AgentSupportsPayload();

	[JsonPropertyName("tools")]
	public JsonElement Tools { get; set; }

	[JsonPropertyName("recentMemory")]
	public JsonElement RecentMemory { get; set; }

	[JsonPropertyName("budgetMonthly")]
	public decimal BudgetMonthly { get; set; }

	[JsonPropertyName("budgetUsed")]
	public decimal BudgetUsed { get; set; }

	[JsonPropertyName("reportsTo")]
	public string ReportsTo { get; set; } = string.Empty;

	[JsonPropertyName("health")]
	public AgentHealthPayload Health { get; set; } = new AgentHealthPayload();
}
