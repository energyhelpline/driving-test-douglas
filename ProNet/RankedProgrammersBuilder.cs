using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class RankedProgrammersBuilder : IProgrammersBuilder
    {
        public IRankCalculator BuildProgrammers(IDictionary<string, IEnumerable<string>> programmerDictionary)
        {
            var programmers = GetDictionaryOfPageRankedProgrammers(programmerDictionary);

            PopulateRecommendations(programmerDictionary, programmers);

            return new RankedProgrammers(programmers.Values);
        }

        private static Dictionary<string, PageRankedProgrammer> GetDictionaryOfPageRankedProgrammers(IDictionary<string, IEnumerable<string>> programmerDictionary)
        {
            return programmerDictionary
                .ToDictionary(programmer => programmer.Key, programmer => new PageRankedProgrammer(programmer.Key));
        }

        private static void PopulateRecommendations(IDictionary<string, IEnumerable<string>> programmerDictionary, Dictionary<string, PageRankedProgrammer> programmers)
        {
            foreach (var pageRankedProgrammer in programmers.Values)
            {
                AddRecommendationsToProgrammer(pageRankedProgrammer, programmers, programmerDictionary[pageRankedProgrammer.Name]);
            }
        }

        private static void AddRecommendationsToProgrammer(PageRankedProgrammer pageRankedProgrammer, Dictionary<string, PageRankedProgrammer> programmers, IEnumerable<string> recommendations)
        {
            foreach (var recommendation in recommendations)
            {
                pageRankedProgrammer.Recommends(programmers[recommendation]);
            }
        }
    }
}