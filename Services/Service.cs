using CitizenFX.Core;
using JetBrains.Annotations;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Rpc;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using System;
using System.Threading.Tasks;

namespace NFive.SDK.Client.Services
{
	[PublicAPI]
	public abstract class Service
	{
		protected readonly ILogger Logger;
		protected readonly ITickManager Ticks;
		protected readonly IEventManager Events;
		protected readonly IRpcHandler Rpc;
		protected readonly ICommandManager Commands;
		protected readonly OverlayManager OverlayManager;
		protected readonly User User;

		protected Service(ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, ICommandManager commands, OverlayManager overlayManager, User user)
		{
			this.Logger = logger;
			this.Ticks = ticks;
			this.Events = events;
			this.Rpc = rpc;
			this.Commands = commands;
			this.OverlayManager = overlayManager;
			this.User = user;
		}

		public virtual Task Loaded() => Task.FromResult(0);

		public virtual Task Started() => Task.FromResult(0);

		protected async Task Delay(int ms)
		{
			await BaseScript.Delay(ms);
		}

		protected async Task Delay(TimeSpan delay)
		{
			await BaseScript.Delay((int)delay.TotalMilliseconds);
		}
	}
}
