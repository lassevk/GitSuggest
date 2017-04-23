using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GitSuggest.SuggestionProviders
{
    internal class PushAsNewBranchSuggestionProvider : ISuggestionProvider
    {
        public async Task<List<Suggestion>> GetSuggestions(GitRepository repository, IConfiguration configuration)
        {
            if ((await repository.GetFileStatus()).Count > 0)
                return new List<Suggestion>();

            var branch = await repository.GetCurrentBranch();
            if (branch == null)
                return new List<Suggestion>();

            var existingUpstream = await repository.GetUpstream(branch);
            if (existingUpstream != null)
                return new List<Suggestion>();

            var remotes = await repository.GetRemotes();
            if (remotes == null)
                return new List<Suggestion>();

            foreach (var remote in remotes)
            {
                string upstream = $"{remote}/{branch}";
                if (await repository.BranchExists(upstream))
                {
                    return new List<Suggestion>
                           {
                               new Suggestion(375, $"Branch '{branch}' is not tracking a remote branch, but branch '{upstream}' exists on '{remote}'", "",
                                              new SuggestedAction($"Push '{branch}' to {remote} and start tracking '{upstream}'", true, $"push {remote} {branch} --set-upstream {upstream}"))
                           };
                }
            }

            var suggestions = new List<Suggestion>();
            foreach (var remote in remotes)
            {
                suggestions.Add(
                                new Suggestion(375, $"Branch '{branch}' is not tracking a remote branch", "",
                                               new SuggestedAction($"Push '{branch}' to {remote} as a new branch and start tracking the remote branch", true, $"push --set-upstream {remote} {branch}")));
            }

            return suggestions;
        }
    }
}
