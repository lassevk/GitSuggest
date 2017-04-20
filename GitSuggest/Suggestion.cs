using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace GitSuggest
{
    public class Suggestion
    {
        public Suggestion(int rank, [NotNull] string title, [NotNull] string description, [NotNull] params SuggestedAction[] actions)
        {
            Rank = rank;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Actions = actions.ToList() ?? throw new ArgumentNullException(nameof(actions));
        }

        [UsedImplicitly]
        public int Rank { get; }

        [NotNull, UsedImplicitly]
        public string Title { get; }

        [NotNull, UsedImplicitly]
        public string Description { get; }

        [NotNull, UsedImplicitly]
        public List<SuggestedAction> Actions { get; }
    }
}