using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AuthCodeRequest
{
	[JsonPropertyName("channel")]
	public string Channel { get; set; } = "";

	[JsonPropertyName("target")]
	public string Target { get; set; } = "";

	[JsonPropertyName("purpose")]
	public string Purpose { get; set; } = "login";
}
