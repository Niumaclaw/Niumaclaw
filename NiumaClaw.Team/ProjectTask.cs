using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class ProjectTask
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 8);

	[JsonPropertyName("title")]
	public string Title { get; set; } = "";

	[JsonPropertyName("assignee")]
	public string Assignee { get; set; } = "";

	[JsonPropertyName("status")]
	public string Status { get; set; } = "todo";

	[JsonPropertyName("update_time")]
	public string UpdateTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

	[JsonPropertyName("result")]
	public string Result { get; set; } = "";

	[JsonPropertyName("priority")]
	public string Priority { get; set; } = "normal";

	[JsonPropertyName("parent_id")]
	public string? ParentId { get; set; }

	[JsonPropertyName("goal_id")]
	public string? GoalId { get; set; }

	[JsonPropertyName("checked_out_by")]
	public string? CheckedOutBy { get; set; }

	[JsonPropertyName("checked_out_at")]
	public string? CheckedOutAt { get; set; }

	[JsonPropertyName("blocked_reason")]
	public string? BlockedReason { get; set; }

	[JsonPropertyName("review_required")]
	public bool ReviewRequired { get; set; }

	[JsonPropertyName("comments")]
	public List<TaskComment> Comments { get; set; } = new List<TaskComment>();

	[JsonPropertyName("context_summary")]
	public string? ContextSummary { get; set; }

	[JsonPropertyName("phase")]
	public string? Phase { get; set; }

	[JsonPropertyName("depends_on")]
	public List<string> DependsOn { get; set; } = new List<string>();

	[JsonPropertyName("deliverable")]
	public string? Deliverable { get; set; }

	[JsonPropertyName("gate")]
	public string? Gate { get; set; }
}
