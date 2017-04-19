using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitSuggest
{
    internal interface ISuggestionProvider
    {
        Task<List<Suggestion>> GetSuggestions(GitRepository repository);
    }
}
