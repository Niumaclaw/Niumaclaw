using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class OrgNodePayload
{
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	[JsonPropertyName("role")]
	public string Role { get; set; } = "";

	[JsonPropertyName("reportsTo")]
	public string? ReportsTo { get; set; }

	[JsonPropertyName("directReports")]
	public List<string> DirectReports { get; set; } = new List<string>();

	[JsonPropertyName("chainOfCommand")]
	public List<string> ChainOfCommand { get; set; } = new List<string>();
}
