using System;
using JetBrains.Annotations;

namespace NFive.SDK.Client.Interface
{
	[PublicAPI]
	public interface IOverlay : IDisposable
	{
		OverlayManager Manager { get; }

		string Name { get; }

		bool Visible { get; }

		dynamic Ready();

		void Show();

		void Hide();

		void Emit(string @event, object data = null);

		void On(string @event, Action action);

		void On<T>(string @event, Action<T> action);

		void On<TReturn>(string @event, Func<TReturn> action);

		void On<T, TReturn>(string @event, Func<T, TReturn> action);
	}
}
