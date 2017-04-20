using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using JetBrains.Annotations;

using static GitSuggest.ReSharperHelpers;

namespace GitSuggest
{
    public class SuggestionEngine
    {
        private const int _RankWindow = 100;

        [NotNull]
        private readonly GitRepository _GitRepository;

        [NotNull]
        private readonly IConfiguration _Configuration;

        public SuggestionEngine([NotNull] string repositoryFolder, [NotNull] IConfiguration configuration)
        {
            _GitRepository = new GitRepository(repositoryFolder ?? throw new ArgumentNullException(nameof(repositoryFolder)));
            _Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [NotNull, ItemNotNull]
        public async Task<List<Suggestion>> GetSuggestions()
        {
            var result = new List<Suggestion>();

            TypeInfo providerInterfaceType = typeof(ISuggestionProvider).GetTypeInfo();
            assume(providerInterfaceType != null);

            var typeInfo = GetType().GetTypeInfo();
            assume(typeInfo?.Assembly?.DefinedTypes != null);
            foreach (TypeInfo providerType in typeInfo.Assembly.DefinedTypes)
            {
                assume(providerType != null);
                if (providerType.IsAbstract)
                    continue;

                if (!providerInterfaceType.IsAssignableFrom(providerType))
                    continue;

                var provider = (ISuggestionProvider)Activator.CreateInstance(providerType.AsType());
                assume(provider != null);
                result.AddRange(await provider.GetSuggestions(_GitRepository, _Configuration));
            }

            if (result.Count <= 1)
                return result;

            result.Sort((suggestion1, suggestion2) =>
                        {
                            assume(suggestion1 != null && suggestion2 != null);
                            return -suggestion1.Rank.CompareTo(suggestion2.Rank);
                        });

            if (!_Configuration.IncludeAllSuggestions)
            {
                var highestSuggestion = result.First();
                assume(highestSuggestion != null);

                var minRank = highestSuggestion.Rank - _RankWindow;

                result.RemoveAll(suggestion =>
                                 {
                                     assume(suggestion != null);
                                     return suggestion.Rank < minRank;
                                 });
            }

            return result;
        }
    }
}
