using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitSuggest.SuggestionProviders
{
    internal class MergeConflictSuggestionProvider : ISuggestionProvider
    {
        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            if (!await repository.IsMergeConflict())
                return new List<Suggestion>();

            return new List<Suggestion>
                   {
                       new Suggestion(1400, "You have a merge conflict that needs to be resolved", "",
                                      new SuggestedAction("View current status", false, "status --verbose"),
                                      new SuggestedAction("Attempt to resolve the merge conflict using your default mergetool", true, "mergetool"))
                   };
        }
    }
}