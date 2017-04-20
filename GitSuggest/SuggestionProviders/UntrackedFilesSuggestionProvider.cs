using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitSuggest.SuggestionProviders
{
    internal class UntrackedFilesSuggestionProvider : ISuggestionProvider
    {
        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            var untrackedFiles = await repository.GetUntrackedFiles();

            if (untrackedFiles.Count == 0)
                return new List<Suggestion>();

            var result = new List<Suggestion>
                         {
                             new Suggestion(1200, "There are untracked files on disk that should be added before committing", "",
                                            new SuggestedAction("List all untracked files", "status"),
                                            SuggestedAction.Verify,
                                            new SuggestedAction("Add all untracked (and unstaged) files to the index", "add .")),
                             new Suggestion(800, "There are untracked files on disk that can be cleaned", "WARNING: Cleaning files will remove them, there is no undo",
                                            new SuggestedAction("Clean all untracked files", "clean -fdx"))
                         };



            return result;
        }
    }
}