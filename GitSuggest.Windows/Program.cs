using System;
using System.IO;
using System.Windows.Forms;

namespace GitSuggest.Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new MainForm();

            string path = LocateGitRepository(Environment.CurrentDirectory) ?? Environment.CurrentDirectory;
            if (args.Length == 1)
            {
                string possiblePath = args[0].TrimEnd('\\', '/');
                if (Directory.Exists(possiblePath))
                    path = LocateGitRepository(possiblePath) ?? possiblePath;
            }

            mainForm.Configure(path, new Configuration());
            Application.Run(mainForm);
        }

        private static string LocateGitRepository(string path)
        {
            while (true)
            {
                string dotGitPath = Path.Combine(path, ".git");
                if (Directory.Exists(dotGitPath) || File.Exists(dotGitPath))
                    return path;

                string parentPath = Path.GetFullPath(Path.Combine(path, ".."));
                if (string.Equals(path, parentPath, StringComparison.CurrentCultureIgnoreCase))
                    return null;

                path = parentPath;
            }
        }
    }
}