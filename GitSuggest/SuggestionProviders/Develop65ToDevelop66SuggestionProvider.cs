using System;

namespace GitSuggest.SuggestionProviders
{
    internal class Develop65ToDevelop66SuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public Develop65ToDevelop66SuggestionProvider()
            : base(branch => branch == "develop/6.5", (string)"develop/6.6", 300)
        {
        }
    }
}