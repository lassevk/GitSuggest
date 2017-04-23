using System;

namespace GitSuggest.SuggestionProviders
{
    internal class Develop65ToDevelop66SuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public Develop65ToDevelop66SuggestionProvider()
            : base("Development branch", branch => branch == "develop/6.5", "develop/6.6", 900, false)
        {
        }
    }
}