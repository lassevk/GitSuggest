using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander;
using Commander.Events;
using Commander.Monitors;

namespace GitSuggest
{
    public class SuggestionEngine
    {
        private readonly string _RepositoryFolder;

        public SuggestionEngine(string repositoryFolder)
        {
            _RepositoryFolder = repositoryFolder ?? throw new ArgumentNullException(nameof(repositoryFolder));
        }

        private async Task<(int errorcode, List<string> output)> ExecuteGit(string arguments)
        {
            var monitor = new ProcessCollectOutputMonitor();
            int exitcode = await ConsoleProcess.ExecuteAsync("git.exe", arguments, _RepositoryFolder, monitor);
            return (exitcode, monitor.Events.OfType<ProcessOutputEvent>().Select(e => e.Line).ToList());
        }

        public async Task<bool> IsValidGitRepository()
        {
            var (exitcode, _) = await ExecuteGit("status");
            return exitcode == 0;
        }
    }
}
