using System;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class ModelEndpointConfig
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = Guid.NewGuid().ToString("N");

	[JsonPropertyName("provider")]
	public string Provider { get; set; } = "";

	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	[JsonPropertyName("version")]
	public string Version { get; set; } = "";

	[JsonPropertyName("baseUrl")]
	public string BaseUrl { get; set; } = "";

	[JsonPropertyName("apiKey")]
	public string ApiKey { get; set; } = "";

	[JsonPropertyName("enabled")]
	public bool Enabled { get; set; } = true;

	[JsonPropertyName("endpointId")]
	public string EndpointId { get; set; } = "";

	[JsonPropertyName("sortOrder")]
	public int SortOrder { get; set; }
}
