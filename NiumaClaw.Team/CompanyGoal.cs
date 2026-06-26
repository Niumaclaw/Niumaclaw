using System;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class CompanyGoal
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 8);

	[JsonPropertyName("title")]
	public string Title { get; set; } = "";

	[JsonPropertyName("description")]
	public string Description { get; set; } = "";

	[JsonPropertyName("status")]
	public string Status { get; set; } = "active";
}
