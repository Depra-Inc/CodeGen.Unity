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
		private const string GENERATE_MENU = MODULE_PATH + "Generate/";
		private const string AUTO_GENERATE_MENU = MODULE_PATH + "Auto-generate on Compile";

		[InitializeOnLoadMethod]
		private static void Init() => Menu.SetChecked(AUTO_GENERATE_MENU, UnityCodeGenSettings.AutoGenerateOnCompile);

		[MenuItem(GENERATE_MENU + "All")]
		private static void GenerateAll() => UnityCodeGenUtility.Generate();

		[MenuItem(AUTO_GENERATE_MENU)]
		private static void ToggleAutoGenerate()
		{
			UnityCodeGenSettings.AutoGenerateOnCompile = UnityCodeGenSettings.AutoGenerateOnCompile == false;
			Menu.SetChecked(AUTO_GENERATE_MENU, UnityCodeGenSettings.AutoGenerateOnCompile);
		}
	}
}