using JetBrains.Annotations;

namespace NFive.SDK.Client.Rpc
{
	/// <summary>
	/// Represents a received RPC event.
	/// </summary>
	[PublicAPI]
	public interface IRpcEvent
	{
		/// <summary>
		/// Gets the event name.
		/// </summary>
		/// <value>
		/// The event name.
		/// </value>
		string Event { get; }

		/// <summary>
		/// Replies to the event with the specified payloads.
		/// </summary>
		/// <param name="payloads">The payloads to reply to the event with.</param>
		void Reply(params object[] payloads);
	}
}
