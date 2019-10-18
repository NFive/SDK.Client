using JetBrains.Annotations;
using NFive.SDK.Core.Configuration;
using NFive.SDK.Core.Diagnostics;

namespace NFive.SDK.Client.Configuration
{
	[PublicAPI]
	public static class ClientConfiguration
	{
		public static LocaleConfiguration Locale { get; set; } = new LocaleConfiguration();

		public static LogConfiguration Log { get; set; } = new LogConfiguration();
	}

	[PublicAPI]
	public class LogConfiguration
	{
		public LogLevel ConsoleLogLevel { get; set; } = LogLevel.Warn;

		public LogLevel MirrorLogLevel { get; set; } = LogLevel.Warn;
	}
}
