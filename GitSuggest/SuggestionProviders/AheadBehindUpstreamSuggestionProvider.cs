using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitSuggest.SuggestionProviders
{
    internal class AheadBehindUpstreamSuggestionProvider : ISuggestionProvider
    {
        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            if (!(await repository.IsCleanWorkingFolder()))
                return new List<Suggestion>();

            var branch = await repository.GetCurrentBranch();
            if (branch == null)
                return new List<Suggestion>();

            var upstream = await repository.GetUpstream(branch);
            if (upstream == null)
                return new List<Suggestion>();

            var (ahead, behind) = await repository.GetAheadBehind(branch, upstream);

            Suggestion suggestion = null;
            if (ahead != 0 && behind != 0)
                suggestion = new Suggestion(500, $"Branch '{branch}' is {ahead} ahead and {behind} behind '{upstream}'", "", new SuggestedAction($"Pull {upstream} into {branch} to update and merge changes", true, "pull"));
            else if (behind != 0)
                suggestion = new Suggestion(500, $"Branch '{branch}' is {behind} behind '{upstream}'", "", new SuggestedAction($"Pull {upstream} into {branch} to update through a fast-forward", true, "pull"));
            else if (ahead != 0)
                suggestion = new Suggestion(500, $"Branch '{branch}' is {ahead} ahead of '{upstream}'", "", new SuggestedAction($"Push {branch} to {upstream} to update remote", true, "push"));

            var result = new List<Suggestion>();
            if (suggestion != null)
                result.Add(suggestion);

            return result;
        }
    }
}
