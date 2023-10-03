﻿// SPDX-License-Identifier: Apache-2.0
// © 2023 Nikolay Melnikov <n.melnikov@depra.org>

using System.Linq;
using Depra.CodeGen.Attributes;
using Depra.CodeGen.Context;
using Depra.CodeGen.Core;
using UnityEditorInternal;
using UnityEngine;

namespace Depra.CodeGen.Samples
{
	[Generator]
	public readonly struct LayersGenerator : ICodeGenerator
	{
		void ICodeGenerator.Execute(GeneratorContext context)
		{
			var tags = InternalEditorUtility.layers
				.Select(x => $"public const int {x.Replace(" ", string.Empty)} = {LayerMask.NameToLayer(x)};");
			var fields = string.Join("\n\t", tags);
			var code = @$"//<auto-generated/>
public static class Layers
{{
    {fields}
}}";
			context.AddCode("Tags & Layers/Layers.Generated.cs", code);
		}
	}
}