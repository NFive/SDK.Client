using JetBrains.Annotations;

namespace NFive.SDK.Client.Rpc
{
	[PublicAPI]
	public interface IRpcHandler
	{
		IRpc Event(string @event);
	}
}
