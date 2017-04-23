using System;

namespace GitSuggest.SuggestionProviders
{
    internal class DevelopMasterAheadBehindSuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public DevelopMasterAheadBehindSuggestionProvider()
            : base(branch => branch == "develop", "master", 100)
        {
        }
    }
}
