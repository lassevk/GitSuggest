using System;

namespace GitSuggest.Windows
{
    public interface ISuggestionContainer
    {
        void PendRefresh(bool isPending);

        void RefreshSuggestions();
    }
}
