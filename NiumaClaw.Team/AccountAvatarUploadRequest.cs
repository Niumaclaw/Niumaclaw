using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class AccountAvatarUploadRequest
{
	[JsonPropertyName("contentType")]
	public string ContentType { get; set; } = "";

	[JsonPropertyName("base64Data")]
	public string Base64Data { get; set; } = "";
}
