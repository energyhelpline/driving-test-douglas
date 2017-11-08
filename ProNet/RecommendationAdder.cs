using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class RecommendationAdder : IRecommendationAdder
    {
        private readonly IProgrammerFactory _programmerFactory;
        private readonly IProgrammersFactory _programmersFactory;

        public RecommendationAdder(IProgrammerFactory programmerFactory, IProgrammersFactory programmersFactory)
        {
            _programmerFactory = programmerFactory;
            _programmersFactory = programmersFactory;
        }

        public Programmers AddRecommendations(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary)
        {
            var programmers = programmerDictionary
                .ToDictionary(programmer => programmer.Key, _programmerFactory.BuildProgrammer);

            ThisIsAVeryLongMethodNameRecommendProgrammers(programmerDictionary, programmers);

            return _programmersFactory.BuildProgrammers(programmers);
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