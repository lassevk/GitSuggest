using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Commander;
using Commander.Events;
using Commander.Monitors;

using JetBrains.Annotations;

using static GitSuggest.ReSharperHelpers;

namespace GitSuggest
{
    internal class GitProcessor
    {
        [NotNull]
        private readonly string _Path;

        [NotNull]
        private readonly Dictionary<string, (int, List<string>)> _CachedResults = new Dictionary<string, (int, List<string>)>();

        [NotNull]
        public string Path => _Path;

        protected GitProcessor([NotNull] string path)
        {
            _Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public async Task<(int errorcode, List<string> output)> ExecuteGit(string arguments)
        {
            (int, List<string>) cachedResult;
            if (_CachedResults.TryGetValue(arguments, out cachedResult))
                return cachedResult;

            cachedResult = await InternalExecuteGit(arguments);
            _CachedResults[arguments] = cachedResult;
            return cachedResult;
        }

        private async Task<(int errorcode, List<string> output)> InternalExecuteGit(string arguments)
        {
            var monitor = new ProcessCollectOutputMonitor();
            var gitTask = ConsoleProcess.ExecuteAsync("git.exe", arguments, _Path, monitor);
            assume(gitTask != null);

            int exitcode = await gitTask;
            return (exitcode, monitor.Events.OfType<ProcessOutputEvent>().Select(e => e?.Line).ToList());
        }
    }
}