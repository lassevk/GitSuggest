using System;
using System.Text;

namespace GitSuggest.SuggestionProviders
{
    internal class FeatureBranchAheadBehindDevelopBranchSuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public FeatureBranchAheadBehindDevelopBranchSuggestionProvider()
            : base(branchName => branchName.StartsWith("feature/"), "develop", 600)
        {
        }
    }
}
