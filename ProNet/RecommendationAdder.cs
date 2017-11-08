using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class RecommendationAdder : IRecommendationAdder
    {
        private readonly IProgrammerBuilder _programmerBuilder;

        public RecommendationAdder(IProgrammerBuilder programmerBuilder)
        {
            _programmerBuilder = programmerBuilder;
        }

        public Programmers AddRecommendations(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary)
        {
            var programmers = programmerDictionary
                .ToDictionary(programmer => programmer.Key, _programmerBuilder.BuildProgrammer);

            ThisIsAVeryLongMethodNameRecommendProgrammers(programmerDictionary, programmers);

            return new Programmers(programmers.Values);
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