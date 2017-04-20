using System;
using System.Threading.Tasks;

namespace GitSuggest
{
    internal class GitRepository : GitProcessor
    {
        public GitRepository(string path)
            : base(path)
        {
        }


        public async Task<bool> IsValidGitRepository()
        {
            var (exitcode, _) = await ExecuteGit("status");
            return exitcode == 0;
        }
    }
}