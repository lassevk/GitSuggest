using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitSuggest.SuggestionProviders
{
    internal class NotAGitRepositorySuggestionProvider : ISuggestionProvider
    {
        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository)
        {
            var result = new List<Suggestion>();

            if (!await repository.IsValidGitRepository())
                result.Add(new Suggestion("This does not seem to be a valid git repository", string.Empty, string.Empty));

            return result;
        }
    }
}
