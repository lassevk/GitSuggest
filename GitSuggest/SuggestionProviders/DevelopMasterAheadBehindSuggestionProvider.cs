using System;

namespace GitSuggest.SuggestionProviders
{
    internal class DevelopMasterAheadBehindSuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public DevelopMasterAheadBehindSuggestionProvider()
            : base("Development branch", branch => branch == "develop", "master", 0, true)
        {
        }
    }
}
