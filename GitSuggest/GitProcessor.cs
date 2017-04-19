using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Commander;
using Commander.Events;
using Commander.Monitors;

namespace GitSuggest
{
    internal class GitProcessor
    {
        private readonly string _Path;
        private readonly Dictionary<string, (int, List<string>)> _CachedResults = new Dictionary<string, (int, List<string>)>();

        protected GitProcessor(string path)
        {
            _Path = path;
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
            int exitcode = await ConsoleProcess.ExecuteAsync("git.exe", arguments, _Path, monitor);
            return (exitcode, monitor.Events.OfType<ProcessOutputEvent>().Select(e => e.Line).ToList());
        }
    }
}