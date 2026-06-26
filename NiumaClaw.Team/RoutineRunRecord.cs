using System;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class RoutineRunRecord
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 8);

	[JsonPropertyName("routine_id")]
	public string RoutineId { get; set; } = "";

	[JsonPropertyName("routine_name")]
	public string RoutineName { get; set; } = "";

	[JsonPropertyName("employee")]
	public string Employee { get; set; } = "";

	[JsonPropertyName("started_at")]
	public string StartedAt { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

	[JsonPropertyName("finished_at")]
	public string? FinishedAt { get; set; }

	[JsonPropertyName("status")]
	public string Status { get; set; } = "running";

	[JsonPropertyName("summary")]
	public string? Summary { get; set; }

	[JsonPropertyName("error_message")]
	public string? ErrorMessage { get; set; }
}
