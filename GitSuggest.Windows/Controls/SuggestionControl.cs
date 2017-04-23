using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using JetBrains.Annotations;

using Linqy;

namespace GitSuggest.Windows.Controls
{
    public partial class SuggestionControl : UserControl
    {
        public SuggestionControl([NotNull] string repositoryPath, [NotNull] Suggestion suggestion, [NotNull] IConfiguration configuration, [NotNull] ISuggestionContainer suggestionContainer)
        {
            if (repositoryPath == null)
                throw new ArgumentNullException(nameof(repositoryPath));
            if (suggestion == null)
                throw new ArgumentNullException(nameof(suggestion));
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
            if (suggestionContainer == null)
                throw new ArgumentNullException(nameof(suggestionContainer));

            InitializeComponent();

            lblTitle.Text = suggestion.Title;
            lblDescription.Text = suggestion.Description;

            if (configuration.Brief || string.IsNullOrWhiteSpace(lblDescription.Text))
                lblDescription.Visible = false;

            int y = 0;
            void addControl(Control control)
            {
                paActions.Controls.Add(control);

                control.Dock = DockStyle.Top;
                control.Top = y;
                control.BringToFront();

                y += control.Height;
            }

            foreach (var action in suggestion.Actions.Lead())
            {
                if (action.Element == SuggestedAction.Verify)
                    continue;

                addControl(new SuggestedActionControl(repositoryPath, action.Element, configuration, suggestionContainer, action.LeadingElement == SuggestedAction.Verify));
            }

            ResizeControlsAndContainer();
        }

        private void SuggestionControl_Resize(object sender, EventArgs e)
        {
            ResizeControlsAndContainer();
        }

        private void ResizeControlsAndContainer()
        {
            lblTitle.MaximumSize = new Size(ClientSize.Width - lblTitle.Left * 2, 0);
            lblDescription.MaximumSize = new Size(ClientSize.Width - lblTitle.Left * 2, 0);

            paActions.Height = paActions.Controls.OfType<Control>().Sum(ctrl => ctrl.Height);

            Height = Controls.OfType<Control>().Where(ctrl => ctrl != lblSeparator).Max(ctrl => ctrl.Bottom) + 4;
        }
    }
}
