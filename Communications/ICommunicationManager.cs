using JetBrains.Annotations;

namespace NFive.SDK.Client.Communications
{
	[PublicAPI]
	public interface ICommunicationManager
	{
		ICommunicationTarget Event(string @event);
	}
}
