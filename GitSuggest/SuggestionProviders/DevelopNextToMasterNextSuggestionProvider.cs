namespace GitSuggest.SuggestionProviders
{
    internal class DevelopNextToMasterNextSuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public DevelopNextToMasterNextSuggestionProvider()
            : base("Development branch", branch => branch == "develop/next", "master", 400, true)
        {
        }
    }
}
