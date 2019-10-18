using System;
using JetBrains.Annotations;

namespace NFive.SDK.Client.Interface
{
	[PublicAPI]
	public abstract class Overlay : IOverlay
	{
		public OverlayManager Manager { get; }

		public string Name => GetType().Name;

		public bool Visible { get; private set; } = true;

		protected Overlay(OverlayManager manager, string fileName)
		{
			this.Manager = manager;

			if (string.IsNullOrEmpty(fileName)) fileName = $"{this.Name}.html";
			
			this.Manager.On("ready", Ready);

			this.Manager.Emit("load-overlay", new
			{
				overlay = this.Name,
				file = fileName
			});
		}

		protected Overlay(OverlayManager manager) : this(manager, null) { }

		public abstract dynamic Ready();

		public void Show()
		{
			this.Manager.Emit("show", true);
			this.Visible = true;
		}

		public void Hide()
		{
			this.Manager.Emit("show", false);
			this.Visible = false;
		}

		public void Emit(string @event, object data = null)
		{
			this.Manager.Emit(@event, data);
		}

		public void On(string @event, Action action)
		{
			this.Manager.On(@event, action);
		}

		public void On<T>(string @event, Action<T> action)
		{
			this.Manager.On(@event, action);
		}

		public void On<TReturn>(string @event, Func<TReturn> action)
		{
			this.Manager.On(@event, action);
		}

		public void On<T, TReturn>(string @event, Func<T, TReturn> action)
		{
			this.Manager.On(@event, action);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing) return;

			this.Manager.Emit("destroy-overlay");
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
