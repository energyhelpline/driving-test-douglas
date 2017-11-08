using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class ProgrammersBuilder : IProgrammersBuilder
    {
        private readonly IProgrammerBuilder _programmerBuilder;

        public ProgrammersBuilder(IProgrammerBuilder programmerBuilder)
        {
            _programmerBuilder = programmerBuilder;
        }

        public Programmers BuildProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary)
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