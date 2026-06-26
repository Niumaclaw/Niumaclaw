using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AuthMePayload
{
	[JsonPropertyName("authenticated")]
	public bool Authenticated { get; set; }

	[JsonPropertyName("accountId")]
	public string AccountId { get; set; } = "";

	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	[JsonPropertyName("displayName")]
	public string DisplayName { get; set; } = "";

	[JsonPropertyName("avatarUrl")]
	public string? AvatarUrl { get; set; }
}
