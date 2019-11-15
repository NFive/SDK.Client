using CitizenFX.Core.Native;
using JetBrains.Annotations;
using NFive.SDK.Core.Input;

namespace NFive.SDK.Client.Input
{
	[PublicAPI]
	public class Hotkey
	{
		/// <summary>
		/// Gets the user input control the hotkey is bound to.
		/// </summary>
		/// <value>The user input control the hotkey is bound to.</value>
		public InputControl Control { get; }

		/// <summary>
		/// Gets the display name of the user input control.
		/// </summary>
		/// <value>The display name of the user input control.</value>
		public string ControlDisplayName => Input.InputControlDisplayNames.TryGetValue(this.Control, out var value) ? value : "Unknown";

		/// <summary>
		/// Gets the game native name of the user input control.
		/// </summary>
		/// <value>The game native name of the user input control.</value>
		public string ControlNativeName => Input.InputControlNativeNames.TryGetValue(this.Control, out var value) ? value : "Unknown";

		/// <summary>
		/// Gets the scaleform name of the user input control.
		/// </summary>
		/// <value>The scaleform name of the user input control.</value>
		public string ScaleformName { get; }

		/// <summary>
		/// Gets the user bound keyboard key for this hotkey <see cref="InputControl"/>.
		/// </summary>
		/// <value>The user bound keyboard key.</value>
		/// <remarks>
		/// This value may not be accurate and may default to <see cref="DefaultKeyboardKey"/> if unable to be detected.
		/// </remarks>
		public KeyCode UserKeyboardKey { get; }

		/// <summary>
		/// Gets the user bound keyboard key friendly display name for this hotkey <see cref="InputControl"/>.
		/// </summary>
		/// <value>The user bound keyboard key friendly display name.</value>
		/// <remarks>
		/// This value may not be accurate and may default to <see cref="DefaultKeyboardKeyDisplayName"/> if unable to be detected.
		/// </remarks>
		public string UserKeyboardKeyDisplayName => Input.KeyCodeDisplayNames.TryGetValue(this.UserKeyboardKey, out var value) ? value : "Unknown";

		public KeyCode DefaultKeyboardKey => Input.InputControlToKeyCodeDefaultMapping.TryGetValue(this.Control, out var value) ? value : KeyCode.Unknown;

		public string DefaultKeyboardKeyDisplayName => Input.KeyCodeDisplayNames.TryGetValue(this.DefaultKeyboardKey, out var value) ? value : "Unknown";

		public ControllerInput ControllerButton => Input.InputControlToControllerInputMapping.TryGetValue(this.Control, out var value) ? value : ControllerInput.None;

		public string ControllerButtonDisplayName => Input.ControllerInputDisplayNames.TryGetValue(this.ControllerButton, out var value) ? value : "Unknown";

		/// <summary>
		/// Initializes a new instance of the <see cref="Hotkey"/> class.
		/// </summary>
		/// <param name="control">The user input control to bind the hotkey to.</param>
		public Hotkey(InputControl control)
		{
			this.Control = control;
			this.ScaleformName = API.GetControlInstructionalButton(0, (int)control, 0); // TODO: InputGroup doesn't seem to do anything?
			this.UserKeyboardKey = Input.ScaleformToKeyCodeMappings.TryGetValue(this.ScaleformName, out var value) ? value : KeyCode.None;
			if (this.UserKeyboardKey == KeyCode.Unknown) this.UserKeyboardKey = this.DefaultKeyboardKey; // TODO: Safe?
		}

		/// <summary>
		/// Determines whether this hotkey is pressed by the user.
		/// </summary>
		/// <returns>
		///   <c>true</c> if this hotkey is pressed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPressed()
		{
			return Input.IsControlPressed(this.Control);
		}

		/// <summary>
		/// Determines whether this hotkey has just been pressed by the user.
		/// </summary>
		/// <returns>
		///   <c>true</c> if this hotkey has just been pressed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsJustPressed()
		{
			return Input.IsControlJustPressed(this.Control);
		}

		/// <summary>
		/// Determines whether this hotkey has just been released by the user.
		/// </summary>
		/// <returns>
		///   <c>true</c> if this hotkey has just been released; otherwise, <c>false</c>.
		/// </returns>
		public bool IsJustReleased()
		{
			return Input.IsControlJustReleased(this.Control);
		}

        /// <inheritdoc/>
		public override string ToString() => $"{this.UserKeyboardKeyDisplayName}/{this.ControllerButtonDisplayName} ({this.ControlDisplayName})";
	}
}
