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
        private readonly SuggestedAction _Action;

        [NotNull]
        private readonly IConfiguration _Configuration;

        public SuggestedActionControl([NotNull] SuggestedAction action, [NotNull] IConfiguration configuration)
        {
            InitializeComponent();

            _Action = action ?? throw new ArgumentNullException(nameof(action));
            _Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

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
    }
}
