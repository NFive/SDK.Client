namespace NFive.SDK.Client.Communications
{
	public interface ICommunicationMessage
	{
		/// <summary>
		/// Replies to the event with the specified payloads.
		/// </summary>
		/// <param name="payloads">The payloads to reply to the event with.</param>
		void Reply(params object[] payloads);
	}
}
