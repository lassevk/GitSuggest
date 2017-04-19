using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace GitSuggest
{
    public class SuggestionEngine
    {
        private readonly GitRepository _GitRepository;

        public SuggestionEngine(string repositoryFolder)
        {
            _GitRepository = new GitRepository(repositoryFolder ?? throw new ArgumentNullException(nameof(repositoryFolder)));
        }

        public async Task<List<Suggestion>> GetSuggestions()
        {
            var result = new List<Suggestion>();
            TypeInfo providerInterfaceType = typeof(ISuggestionProvider).GetTypeInfo();
            foreach (TypeInfo providerType in GetType().GetTypeInfo().Assembly.DefinedTypes)
            {
                if (providerType.IsAbstract)
                    continue;

                if (!providerInterfaceType.IsAssignableFrom(providerType))
                    continue;

                var provider = (ISuggestionProvider)Activator.CreateInstance(providerType.AsType());
                result.AddRange(await provider.GetSuggestions(_GitRepository));
            }

            return result;
        }
    }
}
