using System;
using CitizenFX.Core;

namespace NFive.SDK.Client.Interface
{
	public abstract class Overlay : IOverlay
	{
		public OverlayManager Manager { get; }

		protected Overlay(string fileName, OverlayManager manager)
		{
			this.Manager = manager;

			this.Manager.Nui.Send("load-overlay", new
			{
				plugin = this.Manager.Plugin,
				file = fileName
			});
		}

		public void Show()
		{
			this.Manager.Send("show", true);
		}

		public void Hide()
		{
			this.Manager.Send("show", false);
		}

		protected void Send(string @event, object data = null)
		{
			this.Manager.Send(@event, data);
		}

		protected void Attach(string @event, Action<dynamic, CallbackDelegate> callback)
		{
			this.Manager.Attach(@event, callback);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing) return;

			this.Manager.Send("destroy-overlay");
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
