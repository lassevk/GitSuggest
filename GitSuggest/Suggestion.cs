using System;

namespace GitSuggest
{
    public class Suggestion
    {
        public Suggestion(string title, string description, string arguments)
        {
            Title = title;
            Description = description;
            Arguments = arguments;
        }

        public string Title { get; }

        public string Description { get; }

        public string Arguments { get; }
    }
}