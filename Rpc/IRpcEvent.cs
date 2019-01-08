using JetBrains.Annotations;

namespace NFive.SDK.Client.Rpc
{
	[PublicAPI]
	public interface IRpcEvent
	{
		string Event { get; }

		void Reply(params object[] payloads);
	}
}
