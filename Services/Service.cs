using CitizenFX.Core;
using JetBrains.Annotations;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using System;
using System.Threading.Tasks;
using NFive.SDK.Client.Communications;

namespace NFive.SDK.Client.Services
{
	[PublicAPI]
	public abstract class Service
	{
		protected readonly ILogger Logger;
		protected readonly ITickManager Ticks;
		protected readonly ICommunicationManager Comms;
		protected readonly ICommandManager Commands;
		protected readonly OverlayManager OverlayManager;
		protected readonly User User;

		protected Service(ILogger logger, ITickManager ticks, ICommunicationManager comms, ICommandManager commands, OverlayManager overlayManager, User user)
		{
			this.Logger = logger;
			this.Ticks = ticks;
			this.Comms = comms;
			this.Commands = commands;
			this.OverlayManager = overlayManager;
			this.User = user;
		}

		public virtual Task Loaded() => Task.FromResult(0);

		public virtual Task Started() => Task.FromResult(0);

		public virtual Task HoldFocus() => Task.FromResult(0);

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
