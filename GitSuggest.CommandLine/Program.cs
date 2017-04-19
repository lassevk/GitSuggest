using System;
using System.Threading.Tasks;

namespace GitSuggest.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => MainAsync(args)).Wait();
            Console.WriteLine("done");
        }

        private static async Task MainAsync(string[] args)
        {
            Console.WriteLine("before");
            await Task.Delay(1000);
            Console.WriteLine("after");
        }
    }
}