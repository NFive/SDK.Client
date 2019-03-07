using JetBrains.Annotations;

namespace NFive.SDK.Client.Events
{
	[PublicAPI]
	public static class SessionEvents
	{
		public const string DisconnectPlayer = "nfive:server:sessionmanager:disconnectPlayer";
	}
}
