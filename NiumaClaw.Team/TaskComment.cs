using System;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class TaskComment
{
	[JsonPropertyName("author")]
	public string Author { get; set; } = "";

	[JsonPropertyName("content")]
	public string Content { get; set; } = "";

	[JsonPropertyName("timestamp")]
	public string Timestamp { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
}
