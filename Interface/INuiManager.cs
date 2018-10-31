using System;
using CitizenFX.Core;

namespace NFive.SDK.Client.Interface
{
	public interface INuiManager
	{
		void Send(object data);

		void Attach(string type, Action<dynamic, CallbackDelegate> callback);
	}
}
