using System;
using System.Windows.Forms;

namespace GitSuggest.Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new MainForm();

            mainForm.Configure(@"D:\Dev\VS.NET\GitSuggest", new Configuration());
            Application.Run(mainForm);
        }
    }
}
