// SPDX-License-Identifier: Apache-2.0
// © 2023 Nikolay Melnikov <n.melnikov@depra.org>

namespace Depra.CodeGen.Editor.Common
{
	internal static class Module
	{
		public const string SLASH = "/";
		public const string MODULE_NAME = nameof(CodeGen);
		public const string MODULE_PATH = FRAMEWORK_NAME + SLASH + MODULE_NAME + SLASH;

		private const string FRAMEWORK_NAME = nameof(Depra);
	}
}