using NFive.SDK.Client.Events;

namespace NFive.SDK.Client.Communications
{
	public interface ICommunicationTarget
	{
		IEventManager EventManager { get; }
		string Event { get; }
		ICommunicationTransmitClient ToClient();
		ICommunicationReceiveClient FromClient();
		ICommunicationTransmitServer ToServer();
		ICommunicationReceiveServer FromServer();
	}
}
