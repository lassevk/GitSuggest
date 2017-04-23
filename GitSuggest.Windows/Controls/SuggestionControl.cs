using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using JetBrains.Annotations;

namespace GitSuggest.Windows.Controls
{
    public partial class SuggestionControl : UserControl
    {
        private readonly IConfiguration _Configuration;

        [CanBeNull]
        private readonly Suggestion _Suggestion;

        public SuggestionControl([NotNull] Suggestion suggestion, [NotNull] IConfiguration configuration)
        {
            InitializeComponent();

            _Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _Suggestion = suggestion ?? throw new ArgumentNullException(nameof(suggestion));

            lblTitle.Text = _Suggestion.Title;
            lblDescription.Text = _Suggestion.Description;

            if (_Configuration.Brief || string.IsNullOrWhiteSpace(lblDescription.Text))
                lblDescription.Visible = false;
        }

        private void SuggestionControl_Resize(object sender, EventArgs e)
        {
            lblTitle.MaximumSize = new Size(ClientSize.Width - lblTitle.Left * 2, 0);
            lblDescription.MaximumSize = new Size(ClientSize.Width - lblTitle.Left * 2, 0);

            Height = Controls.OfType<Control>().Where(ctrl => ctrl != lblSeparator).Max(ctrl => ctrl.Bottom) + 4;
        }
    }
}
