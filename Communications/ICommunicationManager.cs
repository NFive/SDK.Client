namespace NFive.SDK.Client.Communications
{
	public interface ICommunicationManager
	{
		ICommunicationTarget Event(string @event);
	}
}
