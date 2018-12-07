using CitizenFX.Core;
using System;

namespace NFive.SDK.Client.Interface
{
	public class OverlayManager
	{
		public string Plugin { get; }

		public INuiManager Nui { get; }

		public OverlayManager(string plugin, INuiManager nui)
		{
			this.Plugin = plugin;
			this.Nui = nui;
		}

		public void Send(string @event, object data = null)
		{
			this.Nui.Send(new
			{
				plugin = this.Plugin,
				@event,
				data
			});
		}

		public void Attach(string @event, Action<dynamic, CallbackDelegate> callback)
		{
			this.Nui.Attach($"{this.Plugin}/{@event}", callback);
		}

		public void Attach<T>(string @event, Action<T, CallbackDelegate> callback)
		{
			this.Nui.Attach($"{this.Plugin}/{@event}", callback);
		}
	}
}
