using System;
using System.Linq;

using JetBrains.Annotations;

namespace GitSuggest.CommandLine
{
    internal class Configuration : IConfiguration
    {
        [NotNull, UsedImplicitly]
        private readonly string[] _CommandLineArguments;

        public Configuration([NotNull] string[] commandLineArguments)
        {
            _CommandLineArguments = commandLineArguments ?? throw new ArgumentNullException(nameof(commandLineArguments));

            IncludeAllSuggestions = _CommandLineArguments.Any(arg => arg == "-a" || arg == "--all");
        }

        public bool IncludeAllSuggestions { get; }
    }
}