using System;

namespace GitSuggest.SuggestionProviders
{
    internal class Develop66ToDevelopNextSuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public Develop66ToDevelopNextSuggestionProvider()
            : base("Development branch", branch => branch == "develop/6.6", "develop/next", 200, false)
        {
        }
    }
}