namespace NFive.SDK.Client.Rpc
{
	public interface IRpcEvent
	{
		string Event { get; }

		void Reply(params object[] payloads);
	}
}
