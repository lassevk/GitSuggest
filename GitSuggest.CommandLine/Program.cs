using System;
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

            var configuration = new Configuration(args);
            var engine = new SuggestionEngine(".", configuration);

            var suggestions = await engine.GetSuggestions();
            foreach (var suggestion in suggestions)
                Console.WriteLine(suggestion.Title);
        }
    }
}