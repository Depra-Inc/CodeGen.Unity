// SPDX-License-Identifier: Apache-2.0
// © 2023 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.CodeGen.Editor.Pipeline;
using Depra.CodeGen.Editor.Settings;
using UnityEditor;
using static Depra.CodeGen.Editor.Common.Module;

namespace Depra.CodeGen.Editor.Menus
{
	internal static class MenuItems
	{
		private const string TOGGLE_AUTO_GENERATE = MODULE_PATH + "Auto-generate on Compile";

		[InitializeOnLoadMethod]
		private static void Init() =>
			Menu.SetChecked(TOGGLE_AUTO_GENERATE, UnityCodeGenSettings.AutoGenerateOnCompile);

		[MenuItem(MODULE_PATH + "Generate All")]
		private static void GenerateAll() => UnityCodeGenUtility.Generate();

		[MenuItem(TOGGLE_AUTO_GENERATE)]
		private static void ToggleAutoGenerate()
		{
			UnityCodeGenSettings.AutoGenerateOnCompile = UnityCodeGenSettings.AutoGenerateOnCompile == false;
			Menu.SetChecked(TOGGLE_AUTO_GENERATE, UnityCodeGenSettings.AutoGenerateOnCompile);
		}
	}
}