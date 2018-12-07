using CitizenFX.Core;
using JetBrains.Annotations;
using System;

namespace NFive.SDK.Client.Interface
{
	[PublicAPI]
	public abstract class Overlay : IOverlay
	{
		public OverlayManager Manager { get; }

		public string Name => this.GetType().Name;

		protected Overlay(string fileName, OverlayManager manager)
		{
			this.Manager = manager;

			this.Manager.Send("load-overlay", new
			{
				overlay = this.Name,
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

		protected void Attach<T>(string @event, Action<T, CallbackDelegate> callback)
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
