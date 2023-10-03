﻿using System.Linq;
using Depra.CodeGen.Attributes;
using Depra.CodeGen.Context;
using Depra.CodeGen.Core;
using UnityEditorInternal;

namespace Depra.CodeGen.Samples
{
	[Generator]
	public readonly struct TagsGenerator : ICodeGenerator
	{
		void ICodeGenerator.Execute(GeneratorContext context)
		{
			var tags = InternalEditorUtility.tags
				.Select(x => $"public const string {x.Replace(" ", string.Empty)} = \"{x}\";");
			var fields = string.Join("\n\t", tags);
			var code =
				@$"//<auto-generated/>
public static class Tags
{{
    {fields}
}}";
			context.AddCode("Tags & Layers/Tags.Generated.cs", code);
		}
	}
}