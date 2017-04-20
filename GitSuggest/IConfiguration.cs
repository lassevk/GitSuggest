using System;

namespace GitSuggest
{
    public interface IConfiguration
    {
        bool IncludeAllSuggestions { get; }
        bool Brief { get; }
    }
}
