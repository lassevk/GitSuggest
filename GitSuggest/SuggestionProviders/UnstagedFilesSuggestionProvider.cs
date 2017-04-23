using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitSuggest.SuggestionProviders
{
    internal class UnstagedFilesSuggestionProvider : ISuggestionProvider
    {
        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            var unstagedFiles = await repository.GetUnstagedFiles();

            if (unstagedFiles.Count == 0)
                return new List<Suggestion>();

            var result = new List<Suggestion>
                         {
                             new Suggestion(1200, "There are unstaged files on disk that should be added before committing", "",
                                            new SuggestedAction("List all unstaged files", false, "status"),
                                            SuggestedAction.Verify,
                                            new SuggestedAction("Add all unstaged (and untracked) files to the index", true, "add .")),
                             new Suggestion(800, "There are unstaged files on disk that can be checked out to undo their content", "WARNING: Checking out a file will remove your local changes, there is no undo")
                         };



            return result;
        }
    }
}