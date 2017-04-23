using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSuggest.SuggestionProviders
{
    internal class OtherBranchesAheadBehindUpstreamSuggestionProvider : ISuggestionProvider
    {
        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            if (!(await repository.IsCleanWorkingFolder()))
                return new List<Suggestion>();

            var branches = await repository.GetBranches();
            if (branches == null)
                return new List<Suggestion>();

            var pushActions = new List<SuggestedAction>();
            var pullActions = new List<SuggestedAction>();
            var mergeActions = new List<SuggestedAction>();
            foreach (var branch in branches)
            {
                if (branch.isCurrent)
                    continue;

                string branchName = branch.branchName;

                var upstream = await repository.GetUpstream(branchName);
                if (upstream == null)
                    continue;

                var (ahead, behind) = await repository.GetAheadBehind(branchName, upstream);
                if (ahead == 0 && behind == 0)
                    continue;

                if (ahead != 0 && behind != 0)
                    mergeActions.Add(new SuggestedAction($"Branch '{branchName}' is {ahead} commit{(ahead != 1 ? "s" : "")} ahead of and {behind} behind '{upstream}', checkout '{branchName}' and pull '{upstream}' into '{branchName}' to update and merge changes", true, $"checkout {branchName}", "pull"));
                else if (behind != 0)
                    pullActions.Add(new SuggestedAction($"Branch '{branchName}' is {behind} commit{(behind != 1 ? "s" : "")} behind '{upstream}', checkout '{branchName}' and pull '{upstream}' into '{branchName}' to update through a fast-forward", true, $"checkout {branchName}", "pull"));
                else if (ahead != 0 && upstream.IndexOf('/') > 0)
                {
                    var remote = upstream.Substring(0, upstream.IndexOf('/'));
                    pushActions.Add(new SuggestedAction($"Branch '{branchName}' is {ahead} commit{(ahead != 1 ? "s" : "")} ahead of '{upstream}', push '{branchName}' to '{upstream}' to update remote", true, $"push {remote} {branchName}"));
                }
            }

            var suggestions = new List<Suggestion>();
            if (mergeActions.Count > 0)
                suggestions.Add(new Suggestion(400, $"You have {mergeActions.Count} branch{(mergeActions.Count != 1 ? "es" : "")} that needs to be merged", "", mergeActions.ToArray()));
            if (pullActions.Count > 0)
                suggestions.Add(new Suggestion(390, $"You have {pullActions.Count} branch{(pullActions.Count != 1 ? "es" : "")} that are behind and can be updated through a fast-forward", "", pullActions.ToArray()));
            if (pushActions.Count > 0)
            {
                if (pushActions.Count > 1)
                    pushActions.Insert(0, new SuggestedAction("Push all branches", true, "push --all"));
                suggestions.Add(new Suggestion(380, $"You have {pushActions.Count} branch{(pushActions.Count != 1 ? "es" : "")} that are ahead of their remote and can be pushed", "", pushActions.ToArray()));
            }

            return suggestions;
        }
    }
}