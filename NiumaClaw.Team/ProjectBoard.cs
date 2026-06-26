using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class ProjectBoard
{
	[JsonPropertyName("project_name")]
	public string? ProjectName { get; set; }

	[JsonPropertyName("tasks")]
	public List<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();

	[JsonPropertyName("goal_id")]
	public string? GoalId { get; set; }

	[JsonPropertyName("project_goal")]
	public string? ProjectGoal { get; set; }

	[JsonPropertyName("context_summary")]
	public string? ContextSummary { get; set; }
}
