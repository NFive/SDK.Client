using CitizenFX.Core;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFive.SDK.Client.Input
{
	[PublicAPI]
	public static class Input
	{
		public static Dictionary<InputModifier, int> ModifierFlagToKeyCode => new Dictionary<InputModifier, int>
		{
			[InputModifier.Ctrl] = 36,
			[InputModifier.Alt] = 19,
			[InputModifier.Shift] = 21
		};

		public static bool WasLastInputFromController => false; // !NativeWrappers.IsInputDisabled(2); TODO

		public static List<Hotkey> UserMappings = new List<Hotkey>();

		public static readonly Dictionary<string, KeyCode> KeyMappings = new Dictionary<string, KeyCode>
		{
			{"b_-1", KeyCode.None}, // Correct?
			{"b_995", KeyCode.None}, // Correct?

			{"b_100", KeyCode.MouseLeftClick},
			{"b_101", KeyCode.MouseRightClick},
			{"b_102", KeyCode.MouseMiddleClick},

			{"b_108", KeyCode.MouseMoveLeft},
			{"b_109", KeyCode.MouseMoveRight},
			{"b_110", KeyCode.MouseMoveUp},
			{"b_111", KeyCode.MouseMoveDown},
			//{ "b_112", Key.MouseMoveLeftRight },
			//{ "b_113", Key.MouseMoveUpDown },

			{"b_115", KeyCode.MouseWheelUp},
			{"b_116", KeyCode.MouseWheelDown},
			//{ "b_117", Key.MouseWheelUpDown },

			{"b_130", KeyCode.NumpadSubtract},
			{"b_131", KeyCode.NumpadAdd},
			{"b_132", KeyCode.NumpadDecimal},
			{"b_133", KeyCode.NumpadDivide},
			{"b_134", KeyCode.NumpadMultiply},
			{"b_135", KeyCode.NumpadEnter},
			{"b_136", KeyCode.Numpad0},
			{"b_137", KeyCode.Numpad1},
			{"b_138", KeyCode.Numpad2},
			{"b_139", KeyCode.Numpad3},
			{"b_140", KeyCode.Numpad4},
			{"b_141", KeyCode.Numpad5},
			{"b_142", KeyCode.Numpad6},
			{"b_143", KeyCode.Numpad7},
			{"b_144", KeyCode.Numpad8},
			{"b_145", KeyCode.Numpad9},
			{"b_146", KeyCode.NumpadEqual},

			{"b_170", KeyCode.F1},
			{"b_171", KeyCode.F2},
			{"b_172", KeyCode.F3},
			{"b_173", KeyCode.F4},
			{"b_174", KeyCode.F5},
			{"b_175", KeyCode.F6},
			{"b_176", KeyCode.F7},
			{"b_177", KeyCode.F8},
			{"b_178", KeyCode.F9},
			{"b_179", KeyCode.F10},
			{"b_180", KeyCode.F11},
			{"b_181", KeyCode.F12},
			{"b_182", KeyCode.F13},
			{"b_183", KeyCode.F14},
			{"b_184", KeyCode.F15},
			{"b_185", KeyCode.F16},
			{"b_186", KeyCode.F17},
			{"b_187", KeyCode.F18},
			{"b_188", KeyCode.F19},
			{"b_189", KeyCode.F20},
			{"b_190", KeyCode.F21},
			{"b_191", KeyCode.F22},
			{"b_192", KeyCode.F23},
			{"b_193", KeyCode.F24},
			{"b_194", KeyCode.ArrowUp},
			{"b_195", KeyCode.ArrowDown},
			{"b_196", KeyCode.ArrowLeft},
			{"b_197", KeyCode.ArrowRight},
			{"b_198", KeyCode.Delete},
			{"b_199", KeyCode.Escape},
			{"b_200", KeyCode.Insert},
			{"b_201", KeyCode.End},

			{"b_1000", KeyCode.ShiftLeft},
			{"b_1001", KeyCode.ShiftRight},
			{"b_1002", KeyCode.Tab},
			{"b_1003", KeyCode.Return},
			{"b_1004", KeyCode.Backspace},
			{"b_1005", KeyCode.PrintScreen},
			{"b_1006", KeyCode.ScrollLock},
			{"b_1007", KeyCode.Pause},
			{"b_1008", KeyCode.Home},
			{"b_1009", KeyCode.PageUp},
			{"b_1010", KeyCode.PageDown},
			{"b_1011", KeyCode.NumLock},
			{"b_1012", KeyCode.CapsLock},
			{"b_1013", KeyCode.ControlLeft},
			{"b_1014", KeyCode.ControlRight},
			{"b_1015", KeyCode.AltLeft},
			{"b_1016", KeyCode.AltRight},
			{"b_1017", KeyCode.ContextMenu},
			{"b_1018", KeyCode.MetaLeft},
			{"b_1019", KeyCode.MetaRight},

			{"b_2000", KeyCode.Space},

			{"t_+", KeyCode.Equal},
			{"t_-", KeyCode.Minus},
			{"t_,", KeyCode.Comma},
			{"t_;", KeyCode.Semicolon},
			{"t_.", KeyCode.Period},
			{"t_[", KeyCode.BracketLeft},
			{"t_]", KeyCode.BracketRight},
			{"t_`", KeyCode.Backquote},
			{"t_=", KeyCode.Equal},
			{"t_0", KeyCode.Digit0},
			{"t_1", KeyCode.Digit1},
			{"t_2", KeyCode.Digit2},
			{"t_3", KeyCode.Digit3},
			{"t_4", KeyCode.Digit4},
			{"t_5", KeyCode.Digit5},
			{"t_6", KeyCode.Digit6},
			{"t_7", KeyCode.Digit7},
			{"t_8", KeyCode.Digit8},
			{"t_9", KeyCode.Digit9},
			{"t_A", KeyCode.KeyA},
			{"t_B", KeyCode.KeyB},
			{"t_C", KeyCode.KeyC},
			{"t_D", KeyCode.KeyD},
			{"t_E", KeyCode.KeyE},
			{"t_F", KeyCode.KeyF},
			{"t_G", KeyCode.KeyG},
			{"t_H", KeyCode.KeyH},
			{"t_I", KeyCode.KeyI},
			{"t_J", KeyCode.KeyJ},
			{"t_K", KeyCode.KeyK},
			{"t_L", KeyCode.KeyL},
			{"t_M", KeyCode.KeyM},
			{"t_N", KeyCode.KeyN},
			{"t_O", KeyCode.KeyO},
			{"t_P", KeyCode.KeyP},
			{"t_Q", KeyCode.KeyQ},
			{"t_R", KeyCode.KeyR},
			{"t_S", KeyCode.KeyS},
			{"t_T", KeyCode.KeyT},
			{"t_U", KeyCode.KeyU},
			{"t_V", KeyCode.KeyV},
			{"t_W", KeyCode.KeyW},
			{"t_X", KeyCode.KeyX},
			{"t_Y", KeyCode.KeyY},
			{"t_Z", KeyCode.KeyZ}
		};

		public static bool IsControlModifierPressed(InputModifier modifier)
		{
			if (modifier == InputModifier.Any) return true;

			InputModifier bitMask = 0;

			ModifierFlagToKeyCode.ToList().ForEach(w =>
			{
				if (Game.IsControlPressed(0, (Control)w.Value)) bitMask = bitMask | w.Key;
			});

			return bitMask == modifier;
		}

		public static bool IsAnyControlJustPressed()
		{
			return Enum.GetValues(typeof(Control)).Cast<Control>().Any(value => IsControlJustPressed(value));
		}

		public static bool IsControlJustPressed(Control control, bool keyboardOnly = true, InputModifier modifier = InputModifier.None)
		{
			return Game.IsControlJustPressed(0, control) && (!keyboardOnly || !WasLastInputFromController) && IsControlModifierPressed(modifier);
		}

		public static bool IsControlPressed(Control control, bool keyboardOnly = true, InputModifier modifier = InputModifier.None)
		{
			return Game.IsControlPressed(0, control) && (!keyboardOnly || !WasLastInputFromController) && IsControlModifierPressed(modifier);
		}

		public static bool IsControlJustReleased(Control control, bool keyboardOnly = true, InputModifier modifier = InputModifier.None)
		{
			return Game.IsControlJustReleased(0, control) && (!keyboardOnly || !WasLastInputFromController) && IsControlModifierPressed(modifier);
		}

		public static bool IsDisabledControlJustPressed(Control control, bool keyboardOnly = true, InputModifier modifier = InputModifier.None)
		{
			return Game.IsDisabledControlJustPressed(0, control) && (!keyboardOnly || !WasLastInputFromController) && IsControlModifierPressed(modifier);
		}

		public static bool IsDisabledControlJustReleased(Control control, bool keyboardOnly = true, InputModifier modifier = InputModifier.None)
		{
			return Game.IsDisabledControlJustReleased(0, control) && (!keyboardOnly || !WasLastInputFromController) && IsControlModifierPressed(modifier);
		}

		public static bool IsDisabledControlPressed(Control control, bool keyboardOnly = true, InputModifier modifier = InputModifier.None)
		{
			return Game.IsDisabledControlPressed(0, control) && (!keyboardOnly || !WasLastInputFromController) && IsControlModifierPressed(modifier);
		}

		public static bool IsEnabledControlJustPressed(Control control, bool keyboardOnly = true, InputModifier modifier = InputModifier.None)
		{
			return Game.IsEnabledControlJustPressed(0, control) && (!keyboardOnly || !WasLastInputFromController) && IsControlModifierPressed(modifier);
		}

		public static bool IsEnabledControlJustReleased(Control control, bool keyboardOnly = true, InputModifier modifier = InputModifier.None)
		{
			return Game.IsEnabledControlJustReleased(0, control) && (!keyboardOnly || !WasLastInputFromController) && IsControlModifierPressed(modifier);
		}

		public static bool IsEnabledControlPressed(Control control, bool keyboardOnly = true, InputModifier modifier = InputModifier.None)
		{
			return Game.IsEnabledControlPressed(0, control) && (!keyboardOnly || !WasLastInputFromController) && IsControlModifierPressed(modifier);
		}
	}
}
