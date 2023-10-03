using Depra.CodeGen.Processing;
using UnityEditor;

namespace Depra.CodeGen.Editor.Pipeline
{
	public readonly struct RefreshAssetDatabasePostProcessor : ICodeGenPostProcessor
	{
		void ICodeGenPostProcessor.Execute() => AssetDatabase.Refresh();
	}
}