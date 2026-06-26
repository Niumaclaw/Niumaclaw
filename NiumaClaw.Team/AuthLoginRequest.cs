using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AuthLoginRequest
{
	[JsonPropertyName("identifier")]
	public string Identifier { get; set; } = "";

	[JsonPropertyName("code")]
	public string? Code { get; set; }

	[JsonPropertyName("password")]
	public string? Password { get; set; }
}
