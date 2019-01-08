using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace NFive.SDK.Client.Events
{
	[PublicAPI]
	public interface ITickManager
	{
		void Attach(Action callback);

		void Attach(Func<Task> callback);

		void Detach(Action callback);

		void Detach(Func<Task> callback);
	}
}
