using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

using GitSuggest.Windows.Controls;
using GitSuggest.Windows.Properties;

using JetBrains.Annotations;

namespace GitSuggest.Windows
{
    internal partial class MainForm : Form, ISuggestionContainer, IConfiguration
    {
        [CanBeNull]
        private SuggestionEngine _SuggestionEngine;

        public MainForm()
        {
            InitializeComponent();

            Text = string.Format(Text, Assembly.GetExecutingAssembly().GetName().Version);
            paRefreshing.Bounds = paSuggestions.Bounds;

            chkAll.Checked = Settings.Default.ShowAll;
            chkBrief.Checked = Settings.Default.Brief;
            chkWait.Checked = Git.DefaultWaitOnSuccess = Settings.Default.WaitAfterSuccess;
        }

        public void Configure([NotNull] string initialRepositoryPath)
        {
            eRepositoryPath.Text = initialRepositoryPath;

#pragma warning disable 4014 // ignore missing await
            RefreshSuggestionEngine();
#pragma warning restore 4014
        }

        private async Task RefreshSuggestionEngine()
        {
            _SuggestionEngine = null;
            string repositoryPath = eRepositoryPath.Text.TrimEnd('/', '\\');
            if (!Directory.Exists(repositoryPath))
            {
                EnableDisableButtons();
                return;
            }

            _SuggestionEngine = new SuggestionEngine(eRepositoryPath.Text, this);
            await RefreshSuggestions();
            var repository = new GitRepository(_SuggestionEngine.RepositoryPath);
            eCurrentBranch.Text = await repository.GetCurrentBranch() ?? string.Empty;
            EnableDisableButtons();
        }

        private void EnableDisableButtons()
        {
            btnFetch.Enabled = _SuggestionEngine != null;
            btnStatus.Enabled = _SuggestionEngine != null;
            chkAll.Enabled = _SuggestionEngine != null;
            chkBrief.Enabled = _SuggestionEngine != null;
        }

        void ISuggestionContainer.PendRefresh(bool isPending)
        {
            paRefreshing.Visible = isPending;
            paRefreshing.BringToFront();
            paSuggestions.Enabled = !isPending;
        }

        void ISuggestionContainer.RefreshSuggestions()
        {
#pragma warning disable 4014
            RefreshSuggestionEngine();
#pragma warning restore 4014
        }

        private async Task RefreshSuggestions()
        {
            paRefreshing.Visible = true;
            paRefreshing.BringToFront();

            paSuggestions.SuspendLayout();

            while (paSuggestions.Controls.Count > 0)
                paSuggestions.Controls[0].Dispose();

            int y = 0;
            void addControl(Control control)
            {
                paSuggestions.Controls.Add(control);

                control.Dock = DockStyle.Top;
                control.Top = y;
                control.BringToFront();

                y += control.Height;
            }

            foreach (var suggestion in await _SuggestionEngine.GetSuggestions())
            {
                if (paSuggestions.Controls.Count > 0)
                    addControl(new Panel { Height = 8 });

                addControl(new SuggestionControl(_SuggestionEngine.RepositoryPath, suggestion, this, this));
            }

            paSuggestions.ResumeLayout();
            paSuggestions.Enabled = true;
            paRefreshing.Visible = false;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshSuggestionEngine();
        }

        private async void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            await RefreshSuggestions();

            Settings.Default.ShowAll = chkAll.Checked;
            Settings.Default.Save();
        }

        private async void chkBrief_CheckedChanged(object sender, EventArgs e)
        {
            await RefreshSuggestions();

            Settings.Default.Brief = chkBrief.Checked;
            Settings.Default.Save();
        }

        private async void btnFetch_Click(object sender, EventArgs e)
        {
            btnStatus.Enabled = false;
            await new Git(_SuggestionEngine.RepositoryPath).Execute("fetch --all --verbose");
            await RefreshSuggestionEngine();
            btnStatus.Enabled = true;
        }

        private async void btnStatus_Click(object sender, EventArgs e)
        {
            btnStatus.Enabled = false;
            await new Git(_SuggestionEngine.RepositoryPath, true).Execute("status --verbose");
            btnStatus.Enabled = true;
        }

        private void chkWait_CheckedChanged(object sender, EventArgs e)
        {
            Git.DefaultWaitOnSuccess = chkWait.Checked;
            Settings.Default.WaitAfterSuccess = chkWait.Checked;
            Settings.Default.Save();
        }

        private void paSuggestions_SizeChanged(object sender, EventArgs e)
        {
            paRefreshing.Bounds = paSuggestions.Bounds;
        }

        private void paSuggestions_LocationChanged(object sender, EventArgs e)
        {
            paRefreshing.Bounds = paSuggestions.Bounds;
        }

        bool IConfiguration.IncludeAllSuggestions => chkAll.Checked;

        bool IConfiguration.Brief => chkBrief.Checked;

        private void btnPrompt_Click(object sender, EventArgs e)
        {
            var prompts = new[]
                          {
                              Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "JPSoft", "TCMD20", "TCC.exe"),
                              Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "JPSoft", "TCMD20", "TCC.exe"),
                              Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "cmd.exe"),
                          };

            foreach (var prompt in prompts)
                if (File.Exists(prompt))
                {
                    Process.Start(new ProcessStartInfo(prompt, "/NOSTART")
                                  {
                                      WorkingDirectory = (_SuggestionEngine?.RepositoryPath ?? eRepositoryPath.Text)
                                  });
                    return;
                }

            MessageBox.Show("Unable to figure out which command prompt process to start");
        }
    }
}