using System;

namespace GitSuggest.Windows
{
    internal class Configuration : IConfiguration
    {
        public bool IncludeAllSuggestions { get; set; }
        public bool Brief { get; set; }
    }
}
