using System;

namespace NiumaClaw.Team;

internal sealed class AgentNodeContext
{
	public long NodeId { get; set; }

	public Guid AccountId { get; set; }

	public string DeviceId { get; set; } = "";

	public string DeviceName { get; set; } = "";
}
