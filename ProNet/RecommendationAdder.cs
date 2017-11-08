using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class RecommendationAdder : IRecommendationAdder
    {
        private readonly IProgrammerBuilder _programmerBuilder;
        private readonly IProgrammersBuilder _programmersBuilder;

        public RecommendationAdder(IProgrammerBuilder programmerBuilder, IProgrammersBuilder programmersBuilder)
        {
            _programmerBuilder = programmerBuilder;
            _programmersBuilder = programmersBuilder;
        }

        public Programmers AddRecommendations(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary)
        {
            var programmers = programmerDictionary
                .ToDictionary(programmer => programmer.Key, _programmerBuilder.BuildProgrammer);

            ThisIsAVeryLongMethodNameRecommendProgrammers(programmerDictionary, programmers);

            return _programmersBuilder.BuildProgrammers(programmers);
        }

        private static void ThisIsAVeryLongMethodNameRecommendProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary, IReadOnlyDictionary<string, IProgrammer> programmers)
        {
            foreach (var pageRankedProgrammer in programmers.Values)
            {
                RecommendProgrammer(pageRankedProgrammer, programmers, programmerDictionary[pageRankedProgrammer.Name]);
            }
        }

        private static void RecommendProgrammer(IProgrammer pageProgrammer, IReadOnlyDictionary<string, IProgrammer> programmers, IEnumerable<string> recommendations)
        {
            foreach (var recommendation in recommendations)
            {
                pageProgrammer.Recommends(programmers[recommendation]);
            }
        }
    }
}