using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using JetBrains.Annotations;

namespace GitSuggest.Windows.Controls
{
    public partial class SuggestedActionControl : UserControl
    {
        [NotNull]
        private readonly string _RepositoryPath;

        [NotNull]
        private readonly ISuggestionContainer _SuggestionContainer;

        [NotNull]
        private readonly SuggestedAction _Action;

        [NotNull]
        private readonly IConfiguration _Configuration;

        [NotNull]
        private readonly bool _ForceWait;

        public SuggestedActionControl([NotNull] string repositoryPath, [NotNull] SuggestedAction action, [NotNull] IConfiguration configuration, [NotNull] ISuggestionContainer suggestionContainer, bool forceWait)
        {
            InitializeComponent();

            _RepositoryPath = repositoryPath ?? throw new ArgumentNullException(nameof(repositoryPath));
            _Action = action ?? throw new ArgumentNullException(nameof(action));
            _Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _SuggestionContainer = suggestionContainer ?? throw new ArgumentNullException(nameof(suggestionContainer));
            _ForceWait = forceWait;

            lblDescription.Text = _Action.Description;

            lblCommands.Text = string.Join(Environment.NewLine, _Action.Commands.Select(cmd => $"git {cmd}"));
            if (configuration.Brief || _Action.Commands.Count == 0)
                paCommands.Visible = false;
            if (_Action.Commands.Count == 0)
                btnExecute.Visible = false;
        }

        private void SuggestedActionControl_SizeChanged(object sender, EventArgs e)
        {
            lblDescription.MaximumSize = new Size(ClientSize.Width - lblDescription.Left - 4, 0);
            if (paCommands.Visible)
            {
                paCommands.Top = lblDescription.Bottom + 4;
                btnExecute.Top = paCommands.Top;
                paCommands.Width = ClientSize.Width - 4 - paCommands.Left;
                paCommands.Height = Math.Max(lblCommands.Height + 2, btnExecute.Height);
            }

            var bottom = Math.Max(btnExecute.Bottom, lblDescription.Bottom);
            if (paCommands.Visible)
                bottom = Math.Max(bottom, paCommands.Bottom);

            Height = bottom + btnExecute.Top;
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            btnExecute.Enabled = false;

            await new Git(_RepositoryPath, _ForceWait).Execute(_Action.Commands.ToArray());

            btnExecute.Enabled = true;
            if (_Action.ShouldRefreshAfterExecuting)
                _SuggestionContainer.RefreshSuggestions();
        }
    }
}
