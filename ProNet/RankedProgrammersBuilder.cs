using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ProNet
{
    [SuppressMessage("CodeCraft.FxCop", "TT1011:IdentifierLengthRule")]
    public class RankedProgrammersBuilder : IProgrammersBuilder
    {
        public RankedProgrammers BuildProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary, IRankedProgrammerBuilder rankedProgrammerBuilder)
        {
            var programmers = programmerDictionary
                .ToDictionary(programmer => programmer.Key, programmer => rankedProgrammerBuilder.BuildProgrammer(programmer));

            RecommendProgrammers(programmerDictionary, programmers);

            return new RankedProgrammers(programmers.Values);
        }

        private static void RecommendProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> programmerDictionary, IReadOnlyDictionary<string, IProgrammer> programmers)
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