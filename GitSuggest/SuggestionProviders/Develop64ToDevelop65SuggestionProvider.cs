using System;
using System.Collections.Generic;
using System.Text;

namespace GitSuggest.SuggestionProviders
{
    internal class Develop64ToDevelop65SuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public Develop64ToDevelop65SuggestionProvider()
            : base("Development branch", branch => branch == "develop/6.4", "develop/6.5", 400, false)
        {
        }
    }
}
