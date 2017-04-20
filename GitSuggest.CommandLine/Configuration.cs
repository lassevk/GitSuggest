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
            Brief = _CommandLineArguments.Any(arg => arg == "-b" || arg == "--brief");
        }

        public bool IncludeAllSuggestions { get; }

        public bool Brief { get; }
    }
}