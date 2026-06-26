using System;
using System.Text.Json.Serialization;

namespace NiumaClaw.Team;

public class NodeDiagnosis
{
	[JsonPropertyName("name")]
	public string Name { get; set; } = "";

	[JsonPropertyName("url")]
	public string Url { get; set; } = "";

	[JsonPropertyName("adapterType")]
	public string AdapterType { get; set; } = "";

	[JsonPropertyName("online")]
	public bool Online { get; set; }

	[JsonPropertyName("configOk")]
	public bool ConfigOk { get; set; }

	[JsonPropertyName("statusOk")]
	public bool StatusOk { get; set; }

	[JsonPropertyName("reason")]
	public string Reason { get; set; } = "";

	[JsonPropertyName("suggestion")]
	public string Suggestion { get; set; } = "";

	[JsonPropertyName("lastCheckedAt")]
	public string LastCheckedAt { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

	[JsonPropertyName("logHint")]
	public string LogHint { get; set; } = "";

	[JsonPropertyName("restartHint")]
	public string RestartHint { get; set; } = "";
}
