using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSuggest.SuggestionProviders
{
    internal class CheckoutOtherBranchSuggestionProvider : ISuggestionProvider
    {
        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            if (!(await repository.IsCleanWorkingFolder()))
                return new List<Suggestion>();

            var branch = await repository.GetCurrentBranch();
            if (branch == null)
                return new List<Suggestion>();

            var branches = await repository.GetBranches();
            if (branches == null)
                return new List<Suggestion>();

            var otherBranches = branches.Where(b => !b.isCurrent).Select(b => b.branchName).ToList();
            var actions = new List<SuggestedAction>();
            foreach (var otherBranch in otherBranches)
            {
                actions.Add(new SuggestedAction($"Check out branch '{otherBranch}'", true, $"checkout {otherBranch}"));
            }

            var suggestions = new List<Suggestion>();
            if (actions.Count > 0)
                suggestions.Add(new Suggestion(100, "You have other branches that you can check out locally", "", actions.ToArray()));
            return suggestions;
        }
    }
}