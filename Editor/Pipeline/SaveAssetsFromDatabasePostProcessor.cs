using Depra.CodeGen.Processing;
using UnityEditor;

namespace Depra.CodeGen.Editor.Pipeline
{
	public readonly struct SaveAssetsFromDatabasePostProcessor : ICodeGenPostProcessor
	{
		void ICodeGenPostProcessor.Execute() => AssetDatabase.SaveAssets();
	}
}