using System;

using JetBrains.Annotations;

namespace GitSuggest
{
    internal static class Extensions
    {
        [ContractAnnotation("null => halt"), NotNull]
        internal static T AssumeNotNull<T>(this T value) => value;
    }
}