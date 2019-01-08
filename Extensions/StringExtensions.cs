using JetBrains.Annotations;

namespace NFive.SDK.Client.Extensions
{
	[PublicAPI]
	public static class StringExtensions
	{
		public static string Pluralize(this string str, int value, string extension = "s")
		{
			return value == 1 ? $"{value} {str}" : $"{value} {str}{extension}";
		}

		public static string Pluralize(this string str, double value, string extension = "s")
		{
			return (int)value == 1 ? $"{value} {str}" : $"{value} {str}{extension}";
		}
	}
}
