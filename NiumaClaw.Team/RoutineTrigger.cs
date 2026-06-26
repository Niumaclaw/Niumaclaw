using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class RoutineTrigger
{
	[JsonPropertyName("trigger_kind")]
	public string TriggerKind { get; set; } = "schedule";

	[JsonPropertyName("cron_expression")]
	public string? CronExpression { get; set; }

	[JsonPropertyName("interval_minutes")]
	public int IntervalMinutes { get; set; }
}
