using System.Text.Json;

namespace NiumaClaw.Team;

public class ChatRequest
{
	public string? message { get; set; }

	public int modelIndex { get; set; }

	public string? sop { get; set; }

	public string? caller { get; set; }

	public string? taskId { get; set; }

	public string? lineageContext { get; set; }

	public JsonElement? snapshotAuditPayload { get; set; }
}
