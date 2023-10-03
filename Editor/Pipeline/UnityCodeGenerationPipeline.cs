// SPDX-License-Identifier: Apache-2.0
// © 2023 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using System.Collections.Generic;
using System.Linq;
using Depra.CodeGen.Attributes;
using Depra.CodeGen.Core;
using Depra.CodeGen.Processing;
using UnityEditor;

namespace Depra.CodeGen.Editor.Pipeline
{
	public sealed class UnityCodeGenerationPipeline : ICodeGenerationPipeline
	{
		private readonly CodeGenerationPipeline _basePipeline;

		public UnityCodeGenerationPipeline(string folderPath) =>
			_basePipeline = new CodeGenerationPipeline(folderPath,
				Enumerable.Empty<ICodeGenPreProcessor>(),
				new ICodeGenPostProcessor[]
				{
					new RefreshAssetDatabasePostProcessor(),
					new SaveAssetsFromDatabasePostProcessor()
				});

		public bool IsGenerating => _basePipeline.IsGenerating;

		public void Generate() => Generate(TypeCache.GetTypesDerivedFrom<ICodeGenerator>()
			.Where(type => type.IsAbstract == false && Attribute.IsDefined(type, typeof(GeneratorAttribute))));

		public void Generate(IEnumerable<Type> types) => _basePipeline.Generate(types);
	}
}