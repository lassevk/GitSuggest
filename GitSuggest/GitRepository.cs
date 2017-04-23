using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using JetBrains.Annotations;

using static GitSuggest.ReSharperHelpers;

namespace GitSuggest
{
    internal class GitRepository : GitProcessor
    {
        public GitRepository([NotNull] string path)
            : base(path)
        {
        }

        public async Task<bool> IsValidGitRepository()
        {
            var (exitcode, _) = await ExecuteGit("status");
            return exitcode == 0;
        }

        public async Task<string> GetCurrentBranch()
        {
            var (exitcode, lines) = await ExecuteGit("rev-parse --abbrev-ref HEAD");
            if (exitcode != 0)
                return null;

            if (lines.Count == 0)
                return null;

            var reference = lines[0]?.Trim();
            if (reference == null)
                return null;

            if (reference == "HEAD")
                return null;

            // TODO: Verify that it is indeed a branch name and not a commit sha
            return reference;
        }

        public async Task<(int ahead, int behind)> GetAheadBehind(string source, string target)
        {
            var (exitcode, lines) = await ExecuteGit($"rev-list --left-right --count {source}...{target}");
            if (exitcode != 0)
                return (0, 0);

            if (lines.Count != 1)
                return (0, 0);

            var line = lines[0]?.Trim();
            if (line == null)
                return (0, 0);

            var parts = line.Split('\t');
            assume(parts != null);

            if (parts.Length != 2)
                return (0, 0);

            if (!int.TryParse(parts[0], out int ahead))
                return (0, 0);

            if (!int.TryParse(parts[1], out int behind))
                return (0, 0);

            return (ahead, behind);
        }

        public async Task<string> GetUpstream(string branch)
        {
            var (exitcode, lines) = await ExecuteGit($@"rev-parse --abbrev-ref --symbolic-full-name {branch}@{{u}}");
            if (exitcode != 0)
                return null;

            if (lines.Count != 1)
                return null;

            return lines[0]?.Trim();
        }

        [NotNull, ItemNotNull, UsedImplicitly]
        public async Task<List<(string index, string local, string path)>> GetFileStatus()
        {
            var (exitcode, lines) = await ExecuteGit("status --short");
            if (exitcode != 0)
                return new List<(string, string, string)>();

            var re = new Regex(@"^(?<index>.)(?<local>.)\s(?<path>.+)$");

            var result = new List<(string, string, string)>();
            foreach (var line in lines)
            {
                var ma = re.Match(line);
                assume(ma != null);

                if (!ma.Success)
                    continue;

                assume(ma.Groups?["index"] != null && ma.Groups["local"] != null && ma.Groups["path"] != null);
                var index = ma.Groups["index"].Value;
                var local = ma.Groups["local"].Value;
                var path = ma.Groups["path"].Value;

                result.Add((index, local, path));
            }

            return result;
        }

        [NotNull, ItemNotNull]
        public async Task<List<string>> GetUntrackedFiles()
        {
            return (await GetFileStatus()).Where(item => item.index == "?").Select(item => item.path).ToList().AssumeNotNull();
        }

        [NotNull, ItemNotNull]
        public async Task<List<string>> GetStagedFiles()
        {
            return (await GetFileStatus()).Where(item => item.index != "?" && item.index != " ").Select(item => item.path).ToList().AssumeNotNull();
        }

        [NotNull, ItemNotNull]
        public async Task<List<string>> GetUnstagedFiles()
        {
            return (await GetFileStatus()).Where(item => item.local != " ").Select(item => item.path).ToList().AssumeNotNull();
        }

        public async Task<bool> BranchExists(string branchName)
        {
            var (exitcode, _) = await ExecuteGit($"rev-parse \"{branchName}\"");
            return exitcode == 0;
        }

        [NotNull, ItemCanBeNull]
        public async Task<List<(bool isCurrent, string branchName)>> GetBranches()
        {
            var (exitcode, lines) = await ExecuteGit($"branch --list");
            if (exitcode != 0)
                return null;

            var result = new List<(bool isCurrent, string branchName)>();
            foreach (var line in lines)
            {
                if (line.Length < 2)
                    continue;

                bool isCurrent = line[0] == '*';
                string branchName = line.Substring(2).Trim();
                if (string.IsNullOrWhiteSpace(branchName))
                    continue;

                result.Add((isCurrent, branchName));
            }

            return result;
        }

        public async Task<List<string>> GetRemotes()
        {
            var (exitcode, lines) = await ExecuteGit("remote");
            if (exitcode != 0)
                return null;

            return lines;
        }
    }
}