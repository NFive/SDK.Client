using System;
using JetBrains.Annotations;

namespace NFive.SDK.Client.Interface
{
	[PublicAPI]
	public abstract class Overlay
	{
		private readonly IOverlayManager manager;

		public string Name => GetType().Name;

		protected Overlay(IOverlayManager manager, string fileName)
		{
			this.manager = manager;

			if (string.IsNullOrEmpty(fileName)) fileName = $"{this.Name}.html";

			this.manager.On("nfive:ready", Ready);

			this.manager.Emit("nfive:load", new
			{
				overlay = this.Name,
				file = fileName
			});
		}

		protected Overlay(IOverlayManager manager) : this(manager, null) { }

		protected virtual dynamic Ready() => null;

		public void Focus(bool showCursor)
		{
			this.manager.Focus(true, showCursor);
		}

		public void Blur()
		{
			this.manager.Focus(false, false);
		}

		public void Show(bool focus = true, bool showCursor = true)
		{
			this.manager.Emit("nfive:visible", true);

			if (focus) Focus(showCursor);
		}

		public void Hide(bool blur = true)
		{
			this.manager.Emit("nfive:visible", false);

			if (blur) Blur();
		}

		public void Emit(string @event, object data = null)
		{
			this.manager.Emit(@event, data);
		}

		public void On(string @event, Action action)
		{
			this.manager.On(@event, action);
		}

		public void On<T>(string @event, Action<T> action)
		{
			this.manager.On(@event, action);
		}

		public void On<TReturn>(string @event, Func<TReturn> action)
		{
			this.manager.On(@event, action);
		}

		public void On<T, TReturn>(string @event, Func<T, TReturn> action)
		{
			this.manager.On(@event, action);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing) return;

			this.manager.Emit("nfive:destroy");
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
