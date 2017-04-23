using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

using GitSuggest.Windows.Controls;

using JetBrains.Annotations;

namespace GitSuggest.Windows
{
    internal partial class MainForm : Form, ISuggestionContainer
    {
        [CanBeNull]
        private SuggestionEngine _SuggestionEngine;

        [CanBeNull]
        private Configuration _Configuration;

        public MainForm()
        {
            InitializeComponent();

            Text = string.Format(Text, Assembly.GetExecutingAssembly().GetName().Version);
            chkWait.Checked = Git.DefaultWaitOnSuccess;
        }

        public void Configure([NotNull] string initialRepositoryPath, [NotNull] Configuration configuration)
        {
            eRepositoryPath.Text = initialRepositoryPath;
            chkAll.Checked = configuration.IncludeAllSuggestions;
            chkBrief.Checked = configuration.Brief;

            _Configuration = configuration;

#pragma warning disable 4014 // ignore missing await
            RefreshSuggestionEngine();
#pragma warning restore 4014
        }

        private async Task RefreshSuggestionEngine()
        {
            if (_Configuration == null)
                return;

            _SuggestionEngine = null;
            string repositoryPath = eRepositoryPath.Text.TrimEnd('/', '\\');
            if (!Directory.Exists(repositoryPath))
            {
                EnableDisableButtons();
                return;
            }

            _SuggestionEngine = new SuggestionEngine(eRepositoryPath.Text, _Configuration);
            await RefreshSuggestions();
            EnableDisableButtons();
        }

        private void EnableDisableButtons()
        {
            btnFetch.Enabled = _SuggestionEngine != null;
            btnStatus.Enabled = _SuggestionEngine != null;
            chkAll.Enabled = _SuggestionEngine != null;
            chkBrief.Enabled = _SuggestionEngine != null;
        }

        void ISuggestionContainer.RefreshSuggestions()
        {
#pragma warning disable 4014
            RefreshSuggestionEngine();
#pragma warning restore 4014
        }

        private async Task RefreshSuggestions()
        {
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

                addControl(new SuggestionControl(_SuggestionEngine.RepositoryPath, suggestion, _Configuration, this));
            }

            paSuggestions.ResumeLayout();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshSuggestionEngine();
        }

        private async void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_Configuration == null)
                return;

            _Configuration.IncludeAllSuggestions = chkAll.Checked;
            await RefreshSuggestions();
        }

        private async void chkBrief_CheckedChanged(object sender, EventArgs e)
        {
            if (_Configuration == null)
                return;

            _Configuration.Brief = chkBrief.Checked;
            await RefreshSuggestions();
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
        }
    }
}