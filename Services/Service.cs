using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Rpc;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using JetBrains.Annotations;

namespace NFive.SDK.Client.Services
{
	[UsedImplicitly]
	public abstract class Service
	{
		protected readonly ILogger Logger;
		protected readonly ITickManager Ticks;
		protected readonly IEventManager Events;
		protected readonly IRpcHandler Rpc;
		protected readonly INuiManager Nui;
		protected readonly User User;

		protected Service(ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, INuiManager nui, User user)
		{
			this.Logger = logger;
			this.Ticks = ticks;
			this.Events = events;
			this.Rpc = rpc;
			this.Nui = nui;
			this.User = user;
		}

		public virtual Task Loaded() => Task.FromResult(0);

		public virtual Task Started() => Task.FromResult(0);

		protected async Task Delay(int msec)
		{
			await BaseScript.Delay(msec);
		}

		protected async Task Delay(TimeSpan delay)
		{
			await BaseScript.Delay((int)delay.TotalMilliseconds);
		}
	}
}
