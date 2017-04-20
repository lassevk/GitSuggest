using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitSuggest.SuggestionProviders
{
    internal class NotAGitRepositorySuggestionProvider : ISuggestionProvider
    {
        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            var result = new List<Suggestion>();

            if (!await repository.IsValidGitRepository())
                result.Add(new Suggestion(99999, "This does not seem to be a valid git repository", string.Empty.AssumeNotNull(), string.Empty.AssumeNotNull()));

            return result;
        }
    }
}
