// SPDX-License-Identifier: Apache-2.0
// © 2023 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.CodeGen.Processing;
using UnityEditor;

namespace Depra.CodeGen.Editor.Pipeline
{
	public readonly struct SaveAssetsFromDatabasePostProcessor : ICodeGenPostProcessor
	{
		void ICodeGenPostProcessor.Execute() => AssetDatabase.SaveAssets();
	}
}