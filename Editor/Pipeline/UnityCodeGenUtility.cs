// SPDX-License-Identifier: Apache-2.0
// © 2023 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using Depra.CodeGen.Core;
using Depra.CodeGen.Editor.Settings;
using UnityEditor;

namespace Depra.CodeGen.Editor.Pipeline
{
	public static class UnityCodeGenUtility
	{
		private static UnityCodeGenerationPipeline _pipeline;

		public static void Generate() =>
			_pipeline.Generate();

		public static void Generate<TGenerator>() where TGenerator : ICodeGenerator =>
			Generate(typeof(TGenerator));

		public static void Generate(params Type[] generatorTypes) =>
			_pipeline.Generate(generatorTypes);

		[InitializeOnLoadMethod]
		private static void Initialize()
		{
			_pipeline = new UnityCodeGenerationPipeline(UnityCodeGenSettings.DEFAULT_FOLDER_PATH);

			if (UnityCodeGenSettings.AutoGenerateOnCompile)
			{
				Generate();
			}
		}
	}
}