using System.Collections.Generic;

namespace NiumaClaw.Team;

public class AppConfig
{
	public string? CompanyProfile { get; set; }

	public string CompanyName { get; set; } = "牛马Claw";

	public bool HasLicense { get; set; }

	public string MasterNodeUrl { get; set; } = "http://127.0.0.1:5050";

	public Dictionary<string, NodeInfo> PeerNodes { get; set; } = new Dictionary<string, NodeInfo>();

	public List<CompanyGoal> CompanyGoals { get; set; } = new List<CompanyGoal>();

	public List<RoutineJob> Routines { get; set; } = new List<RoutineJob>();

	public List<RoutineRunRecord> RoutineHistory { get; set; } = new List<RoutineRunRecord>();

	public Dictionary<string, AgentHeartbeatStatus> AgentHeartbeats { get; set; } = new Dictionary<string, AgentHeartbeatStatus>();

	public string? CompanySOP { get; set; }

	public List<ProjectBoard> Projects { get; set; } = new List<ProjectBoard>();
}
