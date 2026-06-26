using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class LocalNodeModelPayload
{
	[JsonPropertyName("Provider")]
	public string Provider { get; set; } = "";

	[JsonPropertyName("Name")]
	public string Name { get; set; } = "";

	[JsonPropertyName("Version")]
	public string Version { get; set; } = "";

	[JsonPropertyName("BaseUrl")]
	public string BaseUrl { get; set; } = "";

	[JsonPropertyName("ApiKey")]
	public string ApiKey { get; set; } = "";

	[JsonPropertyName("Enabled")]
	public bool Enabled { get; set; } = true;

	[JsonPropertyName("EndpointId")]
	public string EndpointId { get; set; } = "";
}
