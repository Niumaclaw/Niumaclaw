using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class LocalNodeAdminDisabledModel
{
	[JsonPropertyName("provider")]
	public string Provider { get; set; } = "";

	[JsonPropertyName("model")]
	public string Model { get; set; } = "";

	[JsonPropertyName("version")]
	public string Version { get; set; } = "";

	[JsonPropertyName("endpointId")]
	public string EndpointId { get; set; } = "";

	[JsonPropertyName("reason")]
	public string Reason { get; set; } = "";
}
