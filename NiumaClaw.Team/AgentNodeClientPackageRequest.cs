using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AgentNodeClientPackageRequest
{
	[JsonPropertyName("adapterType")]
	public string? AdapterType { get; set; }

	[JsonPropertyName("workspacePath")]
	public string? WorkspacePath { get; set; }

	[JsonPropertyName("deviceId")]
	public string? DeviceId { get; set; }

	[JsonPropertyName("deviceName")]
	public string? DeviceName { get; set; }
}
