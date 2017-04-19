using System;
using System.Threading.Tasks;

namespace GitSuggest.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    Task.Run(() => MainAsync(args)).Wait();
                }
                catch (AggregateException ex) when (ex.InnerExceptions.Count == 1)
                {
                    throw ex.InnerExceptions[0];
                }
            }
            catch (ErrorMessageException ex)
            {
                Console.WriteLine("error: " + ex.Message);

                Environment.Exit(ex.ExitCode);
            }
        }

        private static async Task MainAsync(string[] args)
        {
            var engine = new SuggestionEngine(".");
            var suggestions = await engine.GetSuggestions();
            foreach (var suggestion in suggestions)
                Console.WriteLine(suggestion.Title);
        }
    }
}