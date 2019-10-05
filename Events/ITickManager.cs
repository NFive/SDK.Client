using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace NFive.SDK.Client.Events
{
	[PublicAPI]
	public interface ITickManager
	{
		void On(Action callback);

		void On(Func<Task> callback);

		void Off(Action callback);

		void Off(Func<Task> callback);
	}
}
