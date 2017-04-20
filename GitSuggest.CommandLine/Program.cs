using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using JetBrains.Annotations;

using static GitSuggest.ReSharperHelpers;

namespace GitSuggest.CommandLine
{
    [UsedImplicitly]
    class Program
    {
        [UsedImplicitly]
        static void Main(string[] args)
        {
            assume(args != null);

            try
            {
                try
                {
                    var task = Task.Run(() => MainAsync(args));
                    assume(task != null);
                    task.Wait();
                }
                catch (AggregateException ex) when (ex.InnerExceptions?.Count == 1)
                {
                    assume(ex.InnerExceptions[0] != null);
                    throw ex.InnerExceptions[0];
                }
            }
            catch (ErrorMessageException ex)
            {
                Console.WriteLine("error: " + ex.Message);

                Environment.Exit(ex.ExitCode);
            }
        }

        private static async Task MainAsync([NotNull] string[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            IConfiguration configuration = new Configuration(args);
            var engine = new SuggestionEngine(".", configuration);

            var suggestions = await engine.GetSuggestions();
            var output = new List<string>();
            foreach (var suggestion in suggestions)
            {
                output.Add(suggestion.Title);
                if (!string.IsNullOrWhiteSpace(suggestion.Description) && !configuration.Brief)
                {
                    using (var reader = new StringReader(suggestion.Description))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                            output.Add($"   {line.Trim()}");
                    }

                    output.Add(string.Empty);
                }

                foreach (var action in suggestion.Actions)
                {
                    assume(action != null);
                    if (configuration.Brief)
                    {
                        if (action == SuggestedAction.Verify)
                            output.Add("   --- verify output of previous step");
                        foreach (var command in action.Commands)
                            output.Add($"   $ git {command}");
                    }
                    else
                    {
                        output.Add(string.Empty);
                        if (action == SuggestedAction.Verify)
                            output.Add("   Verify output of previous step");
                        else
                        {
                            output.Add($"   {action.Description}");
                            foreach (var command in action.Commands)
                                output.Add($"      $ git {command}");
                        }
                    }
                }

                output.Add(string.Empty);
            }

            int index = 0;
            while (index < output.Count - 1)
            {
                if (string.IsNullOrWhiteSpace(output[index]) && string.IsNullOrWhiteSpace(output[index + 1]))
                    output.RemoveAt(index);
                else
                    index++;
            }
            while (output.Count > 0 && string.IsNullOrWhiteSpace(output[0]))
                output.RemoveAt(0);
            while (output.Count > 0 && string.IsNullOrWhiteSpace(output[output.Count - 1]))
                output.RemoveAt(output.Count - 1);

            foreach (var line in output)
                Console.WriteLine(line);
        }
    }
}