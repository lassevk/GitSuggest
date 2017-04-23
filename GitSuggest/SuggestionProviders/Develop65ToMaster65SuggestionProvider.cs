﻿namespace GitSuggest.SuggestionProviders
{
    internal class Develop65ToMaster65SuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public Develop65ToMaster65SuggestionProvider()
            : base(branch => branch == "develop/6.5", "master/6.5", 400)
        {
        }
    }
}
