using System;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class RoutineJob
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 8);

	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	[JsonPropertyName("employee")]
	public string Employee { get; set; } = "";

	[JsonPropertyName("enabled")]
	public bool Enabled { get; set; } = true;

	[JsonPropertyName("prompt")]
	public string Prompt { get; set; } = "";

	[JsonPropertyName("trigger")]
	public RoutineTrigger Trigger { get; set; } = new RoutineTrigger();

	[JsonPropertyName("next_run_at")]
	public string? NextRunAt { get; set; }

	[JsonPropertyName("last_run_at")]
	public string? LastRunAt { get; set; }

	[JsonPropertyName("max_retries")]
	public int MaxRetries { get; set; } = 2;

	[JsonPropertyName("retry_backoff_minutes")]
	public int RetryBackoffMinutes { get; set; } = 10;

	[JsonPropertyName("consecutive_failures")]
	public int ConsecutiveFailures { get; set; }

	[JsonPropertyName("last_alert_at")]
	public string? LastAlertAt { get; set; }

	[JsonPropertyName("alert_level")]
	public string? AlertLevel { get; set; }
}
