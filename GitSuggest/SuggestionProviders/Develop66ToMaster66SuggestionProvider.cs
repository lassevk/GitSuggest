namespace GitSuggest.SuggestionProviders
{
    internal class Develop66ToMaster66SuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public Develop66ToMaster66SuggestionProvider()
            : base(branch => branch == "develop/6.6", "master/6.6", 400)
        {
        }
    }
}
