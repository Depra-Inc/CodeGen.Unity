// SPDX-License-Identifier: Apache-2.0
// © 2023 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEditor;
using static Depra.CodeGen.Editor.Common.Module;

namespace Depra.CodeGen.Editor.Settings
{
	internal static class UnityCodeGenSettings
	{
		public const string DEFAULT_FOLDER_PATH = "Assets" + SLASH + "Generated";
		private const string KEY_AUTO_GENERATE = MODULE_NAME + "-AutoGenerateOnCompile";

		public static bool AutoGenerateOnCompile
		{
			get => bool.TryParse(EditorUserSettings.GetConfigValue(KEY_AUTO_GENERATE), out var result) && result;
			set => EditorUserSettings.SetConfigValue(KEY_AUTO_GENERATE, value.ToString());
		}
	}
}