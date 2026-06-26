using System;

namespace NiumaClaw.Team;

internal sealed class AccountContext
{
	public Guid AccountId { get; set; }

	public string? Email { get; set; }

	public string? Phone { get; set; }

	public string DisplayName { get; set; } = "";

	public string? LocalNodeModelsHeader { get; set; }
}
