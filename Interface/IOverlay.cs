using System;

namespace NFive.SDK.Client.Interface
{
	public interface IOverlay : IDisposable
	{
		OverlayManager Manager { get; }
	}
}
