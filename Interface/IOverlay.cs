using JetBrains.Annotations;
using System;

namespace NFive.SDK.Client.Interface
{
	[PublicAPI]
	public interface IOverlay : IDisposable
	{
		OverlayManager Manager { get; }
	}
}
