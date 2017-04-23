using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace GitSuggest.SuggestionProviders
{
    internal abstract class LinkedBranchAheadBehindSuggestionProvider : ISuggestionProvider
    {
        [NotNull]
        private readonly Predicate<string> _BranchNamePredicate;

        [NotNull]
        private readonly string _TargetBranch;

        internal LinkedBranchAheadBehindSuggestionProvider([NotNull] Predicate<string> branchNamePredicate, [NotNull] string targetBranch)
        {
            _BranchNamePredicate = branchNamePredicate;
            _TargetBranch = targetBranch;
            if (branchNamePredicate == null)
                throw new ArgumentNullException(nameof(branchNamePredicate));
            if (targetBranch == null)
                throw new ArgumentNullException(nameof(targetBranch));
        }

        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            if ((await repository.GetFileStatus()).Count > 0)
                return new List<Suggestion>();

            var currentBranch = await repository.GetCurrentBranch();
            if (!currentBranch?.StartsWith("feature/") ?? false)
                return new List<Suggestion>();

            if (!await repository.BranchExists("develop"))
                return new List<Suggestion>();

            var (ahead, behind) = await repository.GetAheadBehind(currentBranch, "develop");
            if (ahead == 0 && behind == 0)
                return new List<Suggestion>();

            var suggestions = new List<Suggestion>();
            if (behind > 0)
            {
                suggestions.Add(new Suggestion(600, $"Feature-branch '{currentBranch}' is {behind} commit{(behind != 1 ? "s" : "")} {_TargetBranch}",
                                               $"This means that other changes have been applied to '{_TargetBranch}' that has not yet been incorporated into '{currentBranch}'",
                                               new SuggestedAction($"Pull from '{_TargetBranch}' into '{currentBranch}'", true, $"pull \"{_TargetBranch}\"")));
            }

            return suggestions;
        }
    }

    internal class FeatureBranchAheadBehindDevelopBranchSuggestionProvider : LinkedBranchAheadBehindSuggestionProvider
    {
        public FeatureBranchAheadBehindDevelopBranchSuggestionProvider()
            : base(branchName => branchName.StartsWith("feature/"), "develop")
        {
        }
    }
}
