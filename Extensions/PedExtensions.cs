using System.Threading.Tasks;
using CitizenFX.Core;
using JetBrains.Annotations;
using Vector3 = NFive.SDK.Core.Models.Vector3;

namespace NFive.SDK.Client.Extensions
{
	[PublicAPI]
	public static class PedExtensions
	{
		public static Vector3 GetPositionInFront(this Ped ped, float distance) => ped.Position.ToVector3().TranslateDir(ped.Heading + 90, distance);

		public static async Task RunTaskSequence(this Ped ped, TaskSequence sequence)
		{
			ped.Task.PerformSequence(sequence);
			while (Game.Player.Character.TaskSequenceProgress < 0) await BaseScript.Delay(100); // Wait for the sequence to start
			while (Game.Player.Character.TaskSequenceProgress > 0) await BaseScript.Delay(100); // Wait for the sequence to end
		}
	}
}
