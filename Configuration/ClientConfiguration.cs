using JetBrains.Annotations;
using NFive.SDK.Core.Diagnostics;

namespace NFive.SDK.Client.Configuration
{
	[PublicAPI]
	public static class ClientConfiguration
	{
		public static LogLevel LogLevel { get; set; } = LogLevel.Debug;
	}
}
