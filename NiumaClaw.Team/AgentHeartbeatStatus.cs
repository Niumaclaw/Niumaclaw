using System;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentHeartbeatStatus
{
	[JsonPropertyName("employee")]
	public string Employee { get; set; } = "";

	[JsonPropertyName("last_seen_at")]
	public string LastSeenAt { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

	[JsonPropertyName("last_status")]
	public string LastStatus { get; set; } = "idle";

	[JsonPropertyName("last_message")]
	public string? LastMessage { get; set; }

	[JsonPropertyName("source")]
	public string? Source { get; set; }

	[JsonPropertyName("alert_level")]
	public string? AlertLevel { get; set; }
}
