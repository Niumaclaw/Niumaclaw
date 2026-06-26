using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class RoutineAlertPayload
{
	[JsonPropertyName("type")]
	public string Type { get; set; } = "routine";

	[JsonPropertyName("routine_id")]
	public string? RoutineId { get; set; }

	[JsonPropertyName("routine_name")]
	public string? RoutineName { get; set; }

	[JsonPropertyName("employee")]
	public string? Employee { get; set; }

	[JsonPropertyName("consecutive_failures")]
	public int ConsecutiveFailures { get; set; }

	[JsonPropertyName("alert_level")]
	public string AlertLevel { get; set; } = "normal";

	[JsonPropertyName("last_alert_at")]
	public string? LastAlertAt { get; set; }

	[JsonPropertyName("last_seen_at")]
	public string? LastSeenAt { get; set; }

	[JsonPropertyName("message")]
	public string Message { get; set; } = "";
}
