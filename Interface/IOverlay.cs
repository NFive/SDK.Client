using System;
using JetBrains.Annotations;

namespace NFive.SDK.Client.Interface
{
	[PublicAPI]
	public interface IOverlay : IDisposable
	{
		OverlayManager Manager { get; }
	}
}
