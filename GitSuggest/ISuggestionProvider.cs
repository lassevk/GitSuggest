using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace GitSuggest
{
    [UsedImplicitly]
    internal interface ISuggestionProvider
    {
        [NotNull, ItemNotNull]
        Task<List<Suggestion>> GetSuggestions([NotNull] GitRepository repository, [NotNull, UsedImplicitly] IConfiguration configuration);
    }
}
