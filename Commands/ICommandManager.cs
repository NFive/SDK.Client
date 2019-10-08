using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace NFive.SDK.Client.Commands
{
	[PublicAPI]
	public interface ICommandManager
	{
		void Register(string command, Action callback);

		void Register(string command, Action<string> callback);

		void Register(string command, Action<IEnumerable<string>> callback);

		void Register<T>(string command, Action<T> callback);
	}
}
