using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AccountProfilePatchRequest
{
	[JsonPropertyName("displayName")]
	public string? DisplayName { get; set; }

	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	[JsonPropertyName("code")]
	public string? Code { get; set; }

	[JsonPropertyName("oldEmailCode")]
	public string? OldEmailCode { get; set; }

	[JsonPropertyName("oldPhoneCode")]
	public string? OldPhoneCode { get; set; }

	[JsonPropertyName("password")]
	public string? Password { get; set; }

	[JsonPropertyName("currentPassword")]
	public string? CurrentPassword { get; set; }
}
