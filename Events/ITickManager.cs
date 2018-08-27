using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace NFive.SDK.Client.Events
{
	[PublicAPI]
	public interface ITickManager
	{
		void Attach(Func<Task> callback);

		void Detach(Func<Task> callback);
	}
}
