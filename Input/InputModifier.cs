using System;

namespace NFive.SDK.Client.Input
{
	[Flags]
	public enum InputModifier
	{
		Any = -1,
		None = 0,
		Ctrl = 1 << 0,
		Alt = 1 << 1,
		Shift = 1 << 2
	}
}
