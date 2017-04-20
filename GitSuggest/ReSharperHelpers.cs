using System;
using System.Diagnostics;

using JetBrains.Annotations;

// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable UnusedParameter.Global
// ReSharper disable InconsistentNaming

namespace GitSuggest
{
    internal static class ReSharperHelpers
    {
        [Conditional("DEBUG")]
        [ContractAnnotation("false => halt")]
        internal static void assume(bool expression)
        {
            // Do nothing
        }
    }

    internal static class Extensions
    {
        [ContractAnnotation("null => halt"), NotNull]
        internal static T AssumeNotNull<T>(this T value) => value;
    }
}
