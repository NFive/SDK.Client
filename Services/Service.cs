using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using JetBrains.Annotations;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Communications;
using NFive.SDK.Client.Configuration;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Locales;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Locales;
using NFive.SDK.Core.Models.Player;
using NGettext;
using NGettext.Loaders;

namespace NFive.SDK.Client.Services
{
	[PublicAPI]
	public abstract class Service
	{
		public static EventHandlerDictionary EventHandlers;
		public static ExportDictionary Exports;
		public static PlayerList Players;

		protected readonly ILogger Logger;
		protected readonly ITickManager Ticks;
		protected readonly ICommunicationManager Comms;
		protected readonly ICommandManager Commands;
		protected readonly IOverlayManager OverlayManager;
		protected readonly User User;
		protected readonly ILocaleCatalog Catalog;

		protected Service(ILogger logger, ITickManager ticks, ICommunicationManager comms, ICommandManager commands, IOverlayManager overlayManager, User user)
		{
			this.Logger = logger;
			this.Ticks = ticks;
			this.Comms = comms;
			this.Commands = commands;
			this.OverlayManager = overlayManager;
			this.User = user;

			// Load empty default catalog
			this.Catalog = new LocaleCatalog(new Catalog(CultureInfo.InvariantCulture));

			var type = GetType();

			// Get all embedded resources
			var catalogs = type.Assembly.GetManifestResourceNames();

			if (!catalogs.Any()) return;

			// Match found cultures with server cultures
			var matches = ClientConfiguration.Locale.Culture.Where(c => catalogs.Contains($"{type.Namespace}.Locales.{c.Name}.mo")).ToList();

			foreach (var culture in matches)
			{
				using (var resourceStream = type.Assembly.GetManifestResourceStream($"{type.Namespace}.Locales.{culture.Name}.mo"))
				{
					if (resourceStream == null) continue;

					try
					{
						// Load MO file locale
						this.Catalog = new LocaleCatalog(new Catalog(new MoLoader(resourceStream, new MoFileParser(Encoding.UTF8, false)), culture));

						this.Logger.Debug($"Loaded locale: {type.Namespace}.Locales.{culture.Name}.mo");

						break;
					}
					catch (Exception ex)
					{
						this.Logger.Error(ex, $"Loading plugin locale catalog failed: {type.Namespace}.Locales.{culture.Name}.mo");
					}
				}
			}
		}

		public string _(string text) => this.Catalog.GetString(text);

		public string _(string text, params object[] args) => this.Catalog.GetString(text, args);

		public string _n(string text, string pluralText, long n) => this.Catalog.GetPluralString(text, pluralText, n);

		public string _n(string text, string pluralText, long n, params object[] args) => this.Catalog.GetPluralString(text, pluralText, n, args);

		public string _p(string context, string text) => this.Catalog.GetParticularString(context, text);

		public string _p(string context, string text, params object[] args) => this.Catalog.GetParticularString(context, text, args);

		public string _pn(string context, string text, string pluralText, long n) => this.Catalog.GetParticularPluralString(context, text, pluralText, n);

		public string _pn(string context, string text, string pluralText, long n, params object[] args) => this.Catalog.GetParticularPluralString(context, text, pluralText, n, args);

		public virtual Task Loaded() => Task.FromResult(0);

		public virtual Task Started() => Task.FromResult(0);

		public virtual Task HoldFocus() => Task.FromResult(0);

		protected async Task Delay(int ms)
		{
			await BaseScript.Delay(ms);
		}

		protected async Task Delay(TimeSpan delay)
		{
			await BaseScript.Delay((int)delay.TotalMilliseconds);
		}
	}
}
