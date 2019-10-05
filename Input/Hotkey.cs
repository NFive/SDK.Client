using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using JetBrains.Annotations;

namespace NFive.SDK.Client.Input
{
	[PublicAPI]
	public class Hotkey
	{
		public Control Control { get; }

		public KeyCode KeyCode { get; }

		public string ScaleformName { get; }

		public string DisplayName { get; }

		public Hotkey(Control control)
		{
			this.Control = control;
			this.ScaleformName = API.GetControlInstructionalButton(0, (int)this.Control, 0);
			this.KeyCode = Input.KeyMappings.ContainsKey(this.ScaleformName) ? Input.KeyMappings[this.ScaleformName] : KeyCode.None; // TODO: KeyCode.Unknown ?
			this.DisplayName = this.KeyCode == KeyCode.None ? this.ScaleformName : Enum.GetName(typeof(KeyCode), this.KeyCode);
		}

		public override string ToString() => this.DisplayName;
	}
}
