using System;
using JetBrains.Annotations;
using NFive.SDK.Core.Chat;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models.Player;

namespace NFive.SDK.Client.Chat
{
	public class ChatMessage : IChatMessage
	{
		public Guid Id { get; set; }
		public User Sender { get; set; }
		public string Content { get; set; }
		[CanBeNull] public User Target { get; set; }

		public ChatMessage()
		{
			this.Id = GuidGenerator.GenerateTimeBasedGuid();
		}
	}
}
