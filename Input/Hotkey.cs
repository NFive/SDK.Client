using System.Linq;
using CitizenFX.Core.Native;
using JetBrains.Annotations;
using NFive.SDK.Core.Input;

namespace NFive.SDK.Client.Input
{
	[PublicAPI]
	public class Hotkey
	{
		public InputControl Control { get; }

		public string ControlDisplayName => Input.ControlDisplayNames.ElementAtOrDefault((int)this.Control) ?? "Unknown";

		public string ControlNativeName => Input.ControlNativeNames.ElementAtOrDefault((int)this.Control) ?? "Unknown";

		public string ScaleformName { get; }

		public KeyCode UserKeyboardKey { get; }

		public string UserKeyboardKeyDisplayName => Input.KeyCodeDisplayNames.TryGetValue(this.UserKeyboardKey, out var value) ? value : "Unknown";

		public KeyCode DefaultKeyboardKey => Input.ControlKeyCodeMapping.ElementAtOrDefault((int)this.Control);

		public string DefaultKeyboardKeyDisplayName => Input.KeyCodeDisplayNames.TryGetValue(this.DefaultKeyboardKey, out var value) ? value : "Unknown";

		public ButtonCode ControllerButton => Input.ControlButtonCodeMapping.ElementAtOrDefault((int)this.Control);

		public string ControllerButtonDisplayName => Input.ButtonCodeDisplayNames.ElementAtOrDefault((int)this.ControllerButton);

		public Hotkey(InputControl control)
		{
			this.Control = control;
			this.ScaleformName = API.GetControlInstructionalButton(0, (int)control, 0); // InputGroup doesn't seem to do anything
			this.UserKeyboardKey = Input.ScaleformKeyCodeMappings.TryGetValue(this.ScaleformName, out var value) ? value : KeyCode.None;
			if (this.UserKeyboardKey == KeyCode.Unknown) this.UserKeyboardKey = this.DefaultKeyboardKey; // TODO: Safe?
		}

		public bool IsPressed()
		{
			return Input.IsControlPressed(this.Control);
		}

		public bool IsJustPressed()
		{

			return Input.IsControlJustPressed(this.Control);
		}

		public bool IsJustReleased()
		{
			return Input.IsControlJustReleased(this.Control);
		}

		public override string ToString() => $"{this.UserKeyboardKeyDisplayName}/{this.ControllerButtonDisplayName} ({this.ControlDisplayName})";
	}
}
