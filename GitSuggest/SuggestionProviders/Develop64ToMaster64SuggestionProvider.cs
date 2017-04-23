namespace GitSuggest.SuggestionProviders
{
    internal class Develop64ToMaster64SuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public Develop64ToMaster64SuggestionProvider()
            : base(branch => branch == "develop/6.4", "master/6.4", 400)
        {
        }
    }
}
