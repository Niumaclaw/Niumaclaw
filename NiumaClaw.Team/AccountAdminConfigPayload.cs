using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AccountAdminConfigPayload
{
	[JsonPropertyName("config")]
	public AppConfig? Config { get; set; }

	[JsonPropertyName("models")]
	public List<ModelEndpointConfig>? Models { get; set; }
}
