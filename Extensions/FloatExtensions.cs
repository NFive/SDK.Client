using JetBrains.Annotations;
using System;

namespace NFive.SDK.Client.Extensions
{
	[PublicAPI]
	public static class FloatExtensions
	{
		public static bool IsBetween(this float val, float min, float max) => val > min && val < max;

		public static float ToRadians(this float val) => (float)(Math.PI / 180 * val);

		public static float Lerp(this float val, float min, float max) => (1 - val) * min + val * max;
	}
}
