using CitizenFX.Core;
using CitizenFX.Core.Native;
using NFive.SDK.Core.Rpc;
using System;

namespace NFive.SDK.Client.Interface
{
	public class NuiManager : INuiManager
	{
		private readonly EventHandlerDictionary events;

		public NuiManager(EventHandlerDictionary events) { this.events = events; }

		public void Send(object data) => API.SendNuiMessage(new Serializer().Serialize(data));

		public void Attach(string type, Action<dynamic, CallbackDelegate> callback)
		{
			API.RegisterNuiCallbackType(type);

			this.events[$"__cfx_nui:{type}"] += callback; // TODO: Dispose
		}

		public void Attach<T>(string type, Action<T, CallbackDelegate> callback)
		{
			Attach(type, (data, cb) =>
			{
				var serializer = new Serializer();

				callback(serializer.Deserialize<T>(serializer.Serialize(data)), cb);
			});
		}
	}
}
