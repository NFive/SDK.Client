using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using NFive.SDK.Core.Rpc;

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
	}
}
