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

            var description = "Other suggestions will usually not appear as long as you have untracked files locally, for fear of destroying uncommitted changes.";
            var result = new List<Suggestion>
                         {
                             new Suggestion(1200, "There are untracked files on disk that should be added before committing", description,
                                            new SuggestedAction("List all untracked files", "status"),
                                            SuggestedAction.Verify,
                                            new SuggestedAction("Add all untracked (and unstaged) files to the index", "add .")),

                new Suggestion(800, "There are untracked files on disk that can be cleaned", description + Environment.NewLine + "WARNING: Cleaning files will remove them, there is no undo",
                                            new SuggestedAction("Clean all untracked files", "clean -fdx"))
                         };



            return result;
        }
    }
}