using System;
using CitizenFX.Core;

namespace NFive.SDK.Client.Interface
{
	public interface INuiManager
	{
		void Send(string type, object data = null);

		void Attach(string type, Action<dynamic, CallbackDelegate> callback);
	}
}
