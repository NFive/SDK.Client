using System;
using JetBrains.Annotations;

namespace NFive.SDK.Client.Interface
{
	[PublicAPI]
	public class OverlayManager
	{
		public string Plugin { get; }

		public INuiManager Nui { get; }

		public OverlayManager(string plugin, INuiManager nui)
		{
			this.Plugin = plugin;
			this.Nui = nui;
		}

		public void Emit(string @event, object data = null)
		{
			this.Nui.Emit(new
			{
				plugin = this.Plugin,
				@event,
				data
			});
		}

		public void On(string @event, Action action)
		{
			this.Nui.On($"{this.Plugin}/{@event}", action);
		}

		public void On<T>(string @event, Action<T> action)
		{
			this.Nui.On($"{this.Plugin}/{@event}", action);
		}

		public void On<TReturn>(string @event, Func<TReturn> action)
		{
			this.Nui.On($"{this.Plugin}/{@event}", action);
		}

		public void On<T, TReturn>(string @event, Func<T, TReturn> action)
		{
			this.Nui.On($"{this.Plugin}/{@event}", action);
		}
	}
}
