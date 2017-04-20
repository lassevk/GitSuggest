using System;

using JetBrains.Annotations;

namespace GitSuggest
{
    public class Suggestion
    {
        public Suggestion(int rank, [NotNull] string title, [NotNull] string description, [NotNull] string arguments)
        {
            Rank = rank;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Arguments = arguments ?? throw new ArgumentNullException(nameof(arguments));
        }

        [UsedImplicitly]
        public int Rank { get; }

        [NotNull, UsedImplicitly]
        public string Title { get; }

        [NotNull, UsedImplicitly]
        public string Description { get; }

        [NotNull, UsedImplicitly]
        public string Arguments { get; }
    }
}