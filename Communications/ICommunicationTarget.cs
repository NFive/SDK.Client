namespace NFive.SDK.Client.Communications
{
	public interface ICommunicationTarget
	{
		/// <summary>
		/// Returns a communication adapter for transmitting, targeting the local client.
		/// </summary>
		/// <returns>A local client targeted communication adapter for transmitting.</returns>
		ICommunicationTransmitClient ToClient();

		/// <summary>
		/// Returns a communication adapter for receiving, targeting the local client.
		/// </summary>
		/// <returns>A local client targeted communication adapter for receiving.</returns>
		ICommunicationReceiveClient FromClient();

		/// <summary>
		/// Returns a communication adapter adapter for transmitting to the server.
		/// </summary>
		/// <returns>A server targeted communication adapter for transmitting.</returns>
		ICommunicationTransmitServer ToServer();

		/// <summary>
		/// Returns a communication adapter for receiving from the server.
		/// </summary>
		/// <returns>A server targeted communication adapter for receiving.</returns>
		ICommunicationReceiveServer FromServer();
	}
}
