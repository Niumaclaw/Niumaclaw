using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class LocalNodeAdminConfigPayload
{
	[JsonPropertyName("baseUrl")]
	public string BaseUrl { get; set; } = "";

	[JsonPropertyName("apiKey")]
	public string ApiKey { get; set; } = "";

	[JsonPropertyName("port")]
	public int Port { get; set; } = 5050;

	[JsonPropertyName("models")]
	public List<ModelEndpointConfig> Models { get; set; } = new List<ModelEndpointConfig>();

	[JsonPropertyName("peerNodes")]
	public Dictionary<string, NodeInfo> PeerNodes { get; set; } = new Dictionary<string, NodeInfo>();

	[JsonPropertyName("configPath")]
	public string ConfigPath { get; set; } = "";
}
