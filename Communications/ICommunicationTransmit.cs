using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace NFive.SDK.Client.Communications
{
	[PublicAPI]
	public interface ICommunicationTransmit
	{
		void Emit(params object[] payloads);

		Task<T1> Request<T1>(params object[] payloads);

		Task<Tuple<T1, T2>> Request<T1, T2>(params object[] payloads);

		Task<Tuple<T1, T2, T3>> Request<T1, T2, T3>(params object[] payloads);

		Task<Tuple<T1, T2, T3, T4>> Request<T1, T2, T3, T4>(params object[] payloads);

		Task<Tuple<T1, T2, T3, T4, T5>> Request<T1, T2, T3, T4, T5>(params object[] payloads);

	}
}
