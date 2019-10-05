using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace NFive.SDK.Client.Events
{
	[PublicAPI]
	public interface IEventManager
	{
		void On(string @event, Action<ICommunicationMessage> action);

		void On<T>(string @event, Action<ICommunicationMessage, T> action);

		void On<T1, T2>(string @event, Action<ICommunicationMessage, T1, T2> action);

		void On<T1, T2, T3>(string @event, Action<ICommunicationMessage, T1, T2, T3> action);

		void On<T1, T2, T3, T4>(string @event, Action<ICommunicationMessage, T1, T2, T3, T4> action);

		void On<T1, T2, T3, T4, T5>(string @event, Action<ICommunicationMessage, T1, T2, T3, T4, T5> action);

		void Emit(string @event, params object[] payload);

		Task<T1> Request<T1>(string @event, params object[] args);

		Task<Tuple<T1, T2>> Request<T1, T2>(string @event, params object[] args);

		Task<Tuple<T1, T2, T3>> Request<T1, T2, T3>(string @event, params object[] args);

		Task<Tuple<T1, T2, T3, T4>> Request<T1, T2, T3, T4>(string @event, params object[] args);

		Task<Tuple<T1, T2, T3, T4, T5>> Request<T1, T2, T3, T4, T5>(string @event, params object[] args);
	}
}
