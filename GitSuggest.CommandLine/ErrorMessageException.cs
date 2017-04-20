using System;

using JetBrains.Annotations;

namespace GitSuggest.CommandLine
{
    [UsedImplicitly]
    internal class ErrorMessageException : Exception
    {
        public ErrorMessageException(int exitcode, string message)
            : base(message)
        {
            ExitCode = exitcode;
        }

        public int ExitCode { get; }
    }
}