using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class NodeInfo
{
	[JsonPropertyName("Name")]
	public string? Name { get; set; }

	[JsonPropertyName("Url")]
	public string? Url { get; set; }

	[JsonPropertyName("Role")]
	public string? Role { get; set; }

	[JsonPropertyName("Description")]
	public string? Description { get; set; }

	[JsonPropertyName("Resume")]
	public string? Resume { get; set; }

	[JsonPropertyName("ModelIndex")]
	public int ModelIndex { get; set; }

	[JsonPropertyName("AdapterType")]
	public string? AdapterType { get; set; }

	[JsonPropertyName("AdapterConfig")]
	public Dictionary<string, JsonElement>? AdapterConfig { get; set; }

	[JsonPropertyName("Capabilities")]
	public List<string>? Capabilities { get; set; }

	[JsonPropertyName("ReportsTo")]
	public string? ReportsTo { get; set; }

	[JsonPropertyName("BudgetMonthly")]
	public decimal? BudgetMonthly { get; set; }

	[JsonPropertyName("BudgetUsed")]
	public decimal? BudgetUsed { get; set; }

	[JsonPropertyName("BudgetSoftLimitRatio")]
	public decimal? BudgetSoftLimitRatio { get; set; }

	[JsonPropertyName("BudgetHardLimitRatio")]
	public decimal? BudgetHardLimitRatio { get; set; }
}
