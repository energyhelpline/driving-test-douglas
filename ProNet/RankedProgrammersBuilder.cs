using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class RankedProgrammersBuilder : IProgrammersBuilder
    {
        public RankedProgrammers BuildProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary)
        {
            var programmers = GetDictionaryOfPageRankedProgrammers(programmerDictionary);

            RecommendProgrammers(programmerDictionary, programmers);

            return new RankedProgrammers(programmers.Values);
        }

        private static IReadOnlyDictionary<string, PageRankedProgrammer> GetDictionaryOfPageRankedProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary)
        {
            return programmerDictionary
                .ToDictionary(programmer => programmer.Key, BuildProgrammer);
        }

        private static PageRankedProgrammer BuildProgrammer(KeyValuePair<string, IEnumerable<string>> programmer)
        {
            return new PageRankedProgrammer(programmer.Key);
        }

        private static void RecommendProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary, IReadOnlyDictionary<string, PageRankedProgrammer> programmers)
        {
            foreach (var pageRankedProgrammer in programmers.Values)
            {
                RecommendProgrammer(pageRankedProgrammer, programmers, programmerDictionary[pageRankedProgrammer.Name]);
            }
        }

        private static void RecommendProgrammer(PageRankedProgrammer pageRankedProgrammer, IReadOnlyDictionary<string, PageRankedProgrammer> programmers, IEnumerable<string> recommendations)
        {
            foreach (var recommendation in recommendations)
            {
                pageRankedProgrammer.Recommends(programmers[recommendation]);
            }
        }
    }
}