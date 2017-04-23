using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

using GitSuggest.Windows.Controls;

using JetBrains.Annotations;

namespace GitSuggest.Windows
{
    internal partial class MainForm : Form
    {
        [CanBeNull]
        private SuggestionEngine _SuggestionEngine;

        [CanBeNull]
        private Configuration _Configuration;

        public MainForm()
        {
            InitializeComponent();

            Text = string.Format(Text, Assembly.GetExecutingAssembly().GetName().Version);
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

            _SuggestionEngine = new SuggestionEngine(eRepositoryPath.Text, _Configuration);
            await RefreshSuggestions();
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

                addControl(new SuggestionControl(suggestion, _Configuration));
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
    }
}