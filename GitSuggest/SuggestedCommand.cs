using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace GitSuggest
{
    public class SuggestedAction
    {
        public SuggestedAction([NotNull] string description, [NotNull] params string[] commands)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));

            Commands = commands.ToList() ?? throw new ArgumentNullException(nameof(commands));
        }

        [NotNull, UsedImplicitly]
        public string Description { get; }

        [NotNull, UsedImplicitly]
        public List<string> Commands { get; }

        [NotNull]
        public static readonly SuggestedAction Verify = new SuggestedAction("VERIFY");
    }
}
