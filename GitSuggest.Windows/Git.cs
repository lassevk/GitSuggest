using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace GitSuggest.Windows
{
    public class Git
    {
        [NotNull]
        private readonly string _RepositoryPath;

        public Git([NotNull] string repositoryPath)
        {
            _RepositoryPath = repositoryPath ?? throw new ArgumentNullException(nameof(repositoryPath));
        }

        public async Task Execute([NotNull] params string[] actions)
        {
            if (actions == null)
                throw new ArgumentNullException(nameof(actions));

            var batchPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().Replace("-", string.Empty) + ".bat");
            try
            {
                var lines = new List<string>();

                lines.Add($"@CD /D {_RepositoryPath}");
                lines.Add("@IF ERRORLEVEL 1 GOTO WAIT");

                foreach (var action in actions)
                {
                    lines.Add($"git.exe {action}");
                    lines.Add("@IF ERRORLEVEL 1 GOTO WAIT");
                }

                lines.Add(":WAIT");
                lines.Add("@ECHO=");
                lines.Add("@PAUSE");

                File.WriteAllLines(batchPath, lines);

                await Task.Run(() => Process.Start(batchPath).WaitForExit());
            }
            finally
            {
                if (File.Exists(batchPath))
                    File.Delete(batchPath);
            }
        }
    }
}