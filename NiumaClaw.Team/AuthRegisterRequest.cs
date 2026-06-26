using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AuthRegisterRequest
{
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	[JsonPropertyName("code")]
	public string Code { get; set; } = "";

	[JsonPropertyName("password")]
	public string? Password { get; set; }

	[JsonPropertyName("displayName")]
	public string? DisplayName { get; set; }
}
