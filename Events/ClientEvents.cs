using JetBrains.Annotations;

namespace NFive.SDK.Client.Events
{
	[PublicAPI]
	public class ClientEvents
	{
		public const string ResourceStart = "nfive:client:resourceStart";

		public const string ResourceStop = "nfive:client:resourceStop";

		public const string PopulationPedCreating = "nfive:client:populationPedCreating";
	}
}
