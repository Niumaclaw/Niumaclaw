using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class LocalNodeAdminDisableResult
{
	[JsonPropertyName("status")]
	public string Status { get; set; } = "ok";

	[JsonPropertyName("checkedCount")]
	public int CheckedCount { get; set; }

	[JsonPropertyName("disabledCount")]
	public int DisabledCount { get; set; }

	[JsonPropertyName("disabledModels")]
	public List<LocalNodeAdminDisabledModel> DisabledModels { get; set; } = new List<LocalNodeAdminDisabledModel>();

	[JsonPropertyName("summary")]
	public string Summary { get; set; } = "";
}
