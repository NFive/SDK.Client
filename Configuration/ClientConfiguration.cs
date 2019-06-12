using JetBrains.Annotations;
using NFive.SDK.Core.Diagnostics;

namespace NFive.SDK.Client.Configuration
{
	[PublicAPI]
	public static class ClientConfiguration
	{
		public static LogLevel ConsoleLogLevel { get; set; } = LogLevel.Info;

		public static LogLevel MirrorLogLevel { get; set; } = LogLevel.Info;
	}
}
