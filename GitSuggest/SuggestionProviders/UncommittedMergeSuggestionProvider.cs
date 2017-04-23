using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitSuggest.SuggestionProviders
{
    internal class UncommittedMergeSuggestionProvider : ISuggestionProvider
    {
        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            var stagedFiles = await repository.GetStagedFiles();

            if (stagedFiles.Count == 0)
                return new List<Suggestion>();

            if (!await repository.IsMerging())
                return new List<Suggestion>();
            if (await repository.IsMergeConflict())
                return new List<Suggestion>();

            var result = new List<Suggestion>
                         {
                             new Suggestion(1200, "You have completed a merge that can be committed", "",
                                            new SuggestedAction("List all staged files", false, "status"),
                                            SuggestedAction.Verify,
                                            new SuggestedAction("Show diff for all staged files", false, "difftool -d --cached"),
                                            SuggestedAction.Verify,
                                            new SuggestedAction("Commit staged files", true, "commit")),
                         };



            return result;
        }
    }
}