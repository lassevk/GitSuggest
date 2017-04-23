using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitSuggest.SuggestionProviders
{
    internal class EmptyGitRepositorySuggestionProvider : ISuggestionProvider
    {
        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            var (exitcode, lines) = await repository.ExecuteGit("branch");
            if (exitcode != 0)
                return new List<Suggestion>();

            if (lines.Count == 0)
            {
                // TODO: Check if there are files or directies on disk
                return new List<Suggestion> { new Suggestion(99999, "Add content to your new repository", "Your repository seems to be empty of commits, and no files or directories on disk exists.") };
            }

            return new List<Suggestion>();
        }
    }
}
