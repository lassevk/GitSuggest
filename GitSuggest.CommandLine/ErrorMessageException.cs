using System;

namespace GitSuggest.CommandLine
{
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