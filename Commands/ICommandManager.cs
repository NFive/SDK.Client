using System;

namespace NFive.SDK.Client.Commands
{
	public interface ICommandManager
	{
		void Register<T>(string command, Action<T> callback);

		void Register(string command, Action callback);
	}
}
