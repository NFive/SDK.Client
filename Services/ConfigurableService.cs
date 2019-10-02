using JetBrains.Annotations;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Rpc;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFive.SDK.Client.Services
{
	public class Style
	{
		public Style(string name, List<string> interiorProps)
		{

		}

		public void Apply()
		{

		}
	}

	public class Detail
	{
		public Detail(string name, List<string> interiorProps)
		{

		}

		public void Apply()
		{

		}
	}

	public abstract class Interior
	{
		public abstract int InteriorId { get; }

		public abstract Style Style { get; set; }

		//public abstract List<InteriorStyles<T>> Styles { get; }
	}

	public class FranklinsHouse : Interior
	{
		public override int InteriorId => 206849;

		public override Style Style { get; set; }

		public List<Style> Styles => new List<Style>
		{
			new Style("empty", new List<string> { "" }),
			new Style("unpacking", new List<string> { "franklin_unpacking" }),
			new Style("settled", new List<string> { "franklin_unpacking", "franklin_settled" }),
			new Style("cardboxes", new List<string> { "showhome_only" })
		};

		public List<Detail> Features => new List<Detail>
		{
			new Detail("GlassDoor", new List<string> { "" })
		};

		public List<Detail> Details => new List<Detail>
		{
			new Detail("flyer", new List<string> { "progress_flyer" }),
			new Detail("tux", new List<string> { "progress_tux" }),
			new Detail("tshirt", new List<string> { "progress_tshirt" }),
			new Detail("bong", new List<string> { "bong_and_wine" })
		};
	}

	// this.Interiors[FranklinsHouse.Id].Details.Bong = false;
	// this.Interiors[FranklinsHouse.Id].Style = FranklinsHouse.Styles.Settled;
	// this.Interiors[FranklinsHouse.Id].GlassDoor = FranklinsHouse.GlassDoor.Open;



	[PublicAPI]
	public abstract class ConfigurableService<T> : Service where T : new()
	{
		protected string ConfigurationRpcEvent { get; private set; }

		/// <summary>
		/// Gets the configuration loaded from file.
		/// </summary>
		/// <value>
		/// The configuration loaded from file.
		/// </value>
		protected T Configuration { get; private set; }

		protected ConfigurableService(string configurationRpcEvent, ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, ICommandManager commands, OverlayManager overlayManager, User user) : base(logger, ticks, events, rpc, commands, overlayManager, user)
		{
			this.ConfigurationRpcEvent = configurationRpcEvent;
		}

		public override async Task Started()
		{
			// Request server configuration
			this.Configuration = await this.Rpc.Event(this.ConfigurationRpcEvent).Request<T>();

			// Update local configuration on server configuration change
			this.Rpc.Event(this.ConfigurationRpcEvent).On<T>((e, c) => Reload(c));
		}

		/// <summary>
		/// Reloads this controllers configuration.
		/// </summary>
		/// <param name="configuration">The updated controller configuration.</param>
		public virtual void Reload(T configuration)
		{
			this.Configuration = configuration;
		}
	}
}
