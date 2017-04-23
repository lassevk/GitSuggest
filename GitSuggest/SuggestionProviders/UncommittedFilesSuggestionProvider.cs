using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitSuggest.SuggestionProviders
{
    internal class UncommittedFilesSuggestionProvider : ISuggestionProvider
    {
        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            if (await repository.IsMergeConflict())
                return new List<Suggestion>();
            var stagedFiles = await repository.GetStagedFiles();

            if (stagedFiles.Count == 0)
                return new List<Suggestion>();

            var result = new List<Suggestion>
                         {
                             new Suggestion(1000, "There are staged files on disk that can be committed", "",
                                            new SuggestedAction("List all staged files", false, "status"),
                                            SuggestedAction.Verify,
                                            new SuggestedAction("Show diff for all staged files", false, "difftool -d --cached"),
                                            SuggestedAction.Verify,
                                            new SuggestedAction("Commit staged files", true, "commit")),
                             new Suggestion(800, "There are staged files on disk that can be checked out to undo their content", "WARNING: Checking out a file will remove your local changes, there is no undo")
                         };



            return result;
        }
    }
}