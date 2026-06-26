using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AccountAdminConfigResponse
{
	[JsonPropertyName("config")]
	public AppConfig Config { get; set; } = new AppConfig();

	[JsonPropertyName("models")]
	public List<ModelEndpointConfig> Models { get; set; } = new List<ModelEndpointConfig>();
}
