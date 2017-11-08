﻿using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class RankedProgrammersBuilder : IProgrammersBuilder
    {
        public RankedProgrammers BuildProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary)
        {
            var programmers = GetDictionaryOfPageRankedProgrammers(programmerDictionary);

            PopulateRecommendations(programmerDictionary, programmers);

            return new RankedProgrammers(programmers.Values);
        }

        private static IReadOnlyDictionary<string, PageRankedProgrammer> GetDictionaryOfPageRankedProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary)
        {
            return programmerDictionary
                .ToDictionary(programmer => programmer.Key, BuildPageRankedProgrammer);
        }

        private static PageRankedProgrammer BuildPageRankedProgrammer(KeyValuePair<string, IEnumerable<string>> programmer)
        {
            return new PageRankedProgrammer(programmer.Key);
        }

        private static void PopulateRecommendations(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary, IReadOnlyDictionary<string, PageRankedProgrammer> programmers)
        {
            foreach (var pageRankedProgrammer in programmers.Values)
            {
                AddRecommendationsToProgrammer(pageRankedProgrammer, programmers, programmerDictionary[pageRankedProgrammer.Name]);
            }
        }

        private static void AddRecommendationsToProgrammer(PageRankedProgrammer pageRankedProgrammer, IReadOnlyDictionary<string, PageRankedProgrammer> programmers, IEnumerable<string> recommendations)
        {
            foreach (var recommendation in recommendations)
            {
                pageRankedProgrammer.Recommends(programmers[recommendation]);
            }
        }
    }
}