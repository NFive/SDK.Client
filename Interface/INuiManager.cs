using CitizenFX.Core;
using System;

namespace NFive.SDK.Client.Interface
{
	public interface INuiManager
	{
		void Send(object data);

		void Attach(string type, Action<dynamic, CallbackDelegate> callback);

		void Attach<T>(string type, Action<T, CallbackDelegate> callback);
	}
}
