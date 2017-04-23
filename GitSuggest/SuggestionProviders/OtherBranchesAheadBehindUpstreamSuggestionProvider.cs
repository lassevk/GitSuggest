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
            if ((await repository.GetFileStatus()).Count > 0)
                return new List<Suggestion>();

            var branches = await repository.GetBranches();
            if (branches == null)
                return new List<Suggestion>();

            var suggestions = new List<Suggestion>();
            var aheadBehindBranches = new List<(string branchName, string upstream, int ahead, int behind)>();
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
                    suggestions.Add(new Suggestion(400, $"Branch '{branchName}' is {ahead} commit{(ahead != 1 ? "s" : "")} ahead of and {behind} behind '{upstream}'", "",
                                                   new SuggestedAction($"Checkout '{branch}' and pull '{upstream}' into '{branchName}' to update and merge changes", true, $"checkout {branchName}", "pull")));
                else if (behind != 0)
                    suggestions.Add(new Suggestion(400, $"Branch '{branch}' is {behind} commit{(behind != 1 ? "s" : "")} behind '{upstream}'", "",
                                                   new SuggestedAction($"Checkout '{branchName}' and pull '{upstream}' into '{branch}' to update through a fast-forward", true, $"checkout {branchName}", "pull")));
                else if (ahead != 0 && upstream.IndexOf('/') > 0)
                {
                    var remote = upstream.Substring(0, upstream.IndexOf('/'));
                    suggestions.Add(new Suggestion(500, $"Branch '{branch}' is {ahead} commit{(ahead != 1 ? "s" : "")} ahead of '{upstream}'", "",
                                                   new SuggestedAction($"Push '{branch}' to '{upstream}' to update remote", true, $"push {remote} {branchName}")));
                }
            }

            return suggestions;
        }
    }
}