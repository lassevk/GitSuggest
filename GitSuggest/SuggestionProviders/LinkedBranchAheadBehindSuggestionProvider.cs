using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace GitSuggest.SuggestionProviders
{
    internal abstract class LinkedBranchAheadBehindSuggestionProvider : ISuggestionProvider
    {
        [NotNull]
        private readonly string _BranchType;

        [NotNull]
        private readonly Predicate<string> _BranchNamePredicate;

        [NotNull]
        private readonly string _TargetBranch;

        private readonly int _Rank;
        private readonly bool _AllowMergeToCurrent;

        internal LinkedBranchAheadBehindSuggestionProvider([NotNull] string branchType, [NotNull] Predicate<string> branchNamePredicate, [NotNull] string targetBranch, int rank, bool allowMergeToCurrent)
        {
            _BranchType = branchType ?? throw new ArgumentNullException(nameof(branchType));
            _BranchNamePredicate = branchNamePredicate ?? throw new ArgumentNullException(nameof(branchNamePredicate));
            _TargetBranch = targetBranch ?? throw new ArgumentNullException(nameof(targetBranch));
            _Rank = rank;
            _AllowMergeToCurrent = allowMergeToCurrent;
        }

        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            if ((await repository.GetFileStatus()).Count > 0)
                return new List<Suggestion>();

            var currentBranch = await repository.GetCurrentBranch();
            if (currentBranch == null || !_BranchNamePredicate(currentBranch))
                return new List<Suggestion>();

            if (!await repository.BranchExists(_TargetBranch))
                return new List<Suggestion>();

            var (ahead, behind) = await repository.GetAheadBehind(currentBranch, _TargetBranch);
            if (ahead == 0 && behind == 0)
                return new List<Suggestion>();

            var suggestions = new List<Suggestion>();
            if (behind > 0 && _AllowMergeToCurrent)
            {
                suggestions.Add(new Suggestion(_Rank, $"{_BranchType} '{currentBranch}' is {behind} commit{(behind != 1 ? "s" : "")} behind '{_TargetBranch}'",
                                               $"This means that other changes have been applied to '{_TargetBranch}' that has not yet been incorporated into '{currentBranch}'",
                                               new SuggestedAction($"View a diff between '{currentBranch}' and '{_TargetBranch}'", false, $"difftool -d \"{currentBranch}\" \"{_TargetBranch}\""),
                                               SuggestedAction.Verify,
                                               new SuggestedAction($"Merge '{_TargetBranch}' into '{currentBranch}'", true, $"merge \"{_TargetBranch}\"")));
            }
            if (ahead > 0)
            {
                suggestions.Add(new Suggestion(_Rank - 25, $"{_BranchType} '{currentBranch}' is {ahead} commit{(ahead != 1 ? "s" : "")} ahead of '{_TargetBranch}'",
                                               $"This means that you have commit on '{currentBranch}' that have not been incorporated into '{_TargetBranch}'",
                                               new SuggestedAction($"View a diff between '{currentBranch}' and '{_TargetBranch}'", false, $"difftool -d \"{currentBranch}\" \"{_TargetBranch}\""),
                                               SuggestedAction.Verify,
                                               new SuggestedAction($"Check out '{_TargetBranch}' and merge from '{currentBranch}'", true, $"checkout {_TargetBranch}", $"merge {currentBranch}")));
            }

            return suggestions;
        }
    }
}