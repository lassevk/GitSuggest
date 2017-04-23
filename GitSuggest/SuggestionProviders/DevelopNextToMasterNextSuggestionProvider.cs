namespace GitSuggest.SuggestionProviders
{
    internal class DevelopNextToMasterNextSuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public DevelopNextToMasterNextSuggestionProvider()
            : base(branch => branch == "develop/next", "master", 400)
        {
        }
    }
}
