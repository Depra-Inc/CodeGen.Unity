using System.Collections.Generic;
using System.Linq;
using Depra.CodeGen.Attributes;
using Depra.CodeGen.Context;
using Depra.CodeGen.Core;
using UnityEditor;

namespace Depra.CodeGen.Samples
{
	[Generator]
	public sealed class SortingLayersGenerator : ICodeGenerator
	{
		void ICodeGenerator.Execute(GeneratorContext context)
		{
			const string TAR_MANAGER_PATH = "ProjectSettings/TagManager.asset";

			var tagManagerAsset = AssetDatabase.LoadAllAssetsAtPath(TAR_MANAGER_PATH);
			var tagManager = new SerializedObject(tagManagerAsset[0]);
			var sortingLayer = tagManager.FindProperty("m_SortingLayers");
			
			var list = new List<string>();
			for (var index = 0; index < sortingLayer.arraySize; ++index)
			{
				list.Add(sortingLayer.GetArrayElementAtIndex(index).displayName);
			}

			var layers = list
				.Select(x => $"public const string {x.Replace(" ", string.Empty)} = \"{x}\";");
			var fields = string.Join("\n\t", layers);
			var code =
				@$"//<auto-generated/>
public static class SortingLayers
{{
    {fields}
}}";
			context.AddCode("Tags & Layers/SortingLayers.Generated.cs", code);
		}
	}
}