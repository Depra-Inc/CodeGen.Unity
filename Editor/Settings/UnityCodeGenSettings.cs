using UnityEditor;
using static Depra.CodeGen.Editor.Common.Module;

namespace Depra.CodeGen.Editor.Settings
{
	internal static class UnityCodeGenSettings
	{
		public const string DEFAULT_FOLDER_PATH = "Assets" + SLASH + "Generated";
		private const string KEY_GENERATE_ON_COMPILE = MODULE_NAME + "-AutoGenerateOnCompile";

		public static bool AutoGenerateOnCompile
		{
			get => bool.TryParse(EditorUserSettings.GetConfigValue(KEY_GENERATE_ON_COMPILE), out var result) && result;
			set => EditorUserSettings.SetConfigValue(KEY_GENERATE_ON_COMPILE, value.ToString());
		}
	}
}