using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace GitSuggest
{
    public class SuggestedAction
    {
        public SuggestedAction([NotNull] string description, bool shouldRefreshAfterExecuting, [NotNull] params string[] commands)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));

            Commands = commands.ToList() ?? throw new ArgumentNullException(nameof(commands));
            ShouldRefreshAfterExecuting = shouldRefreshAfterExecuting;
        }

        [NotNull, UsedImplicitly]
        public string Description { get; }

        [NotNull, UsedImplicitly]
        public List<string> Commands { get; }

        public bool ShouldRefreshAfterExecuting { get; }

        [NotNull]
        public static readonly SuggestedAction Verify = new SuggestedAction("VERIFY", false);
    }
}
