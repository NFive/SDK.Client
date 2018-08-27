namespace NFive.SDK.Client.Rpc
{
	public interface IRpcHandler
	{
		IRpc Event(string @event);
	}
}
