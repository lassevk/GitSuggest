using System;

namespace GitSuggest.SuggestionProviders
{
    internal class Develop66ToDevelopNextSuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public Develop66ToDevelopNextSuggestionProvider()
            : base(branch => branch == "develop/6.6", (string)"develop/next", 200)
        {
        }
    }
}