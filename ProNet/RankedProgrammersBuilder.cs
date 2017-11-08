using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class RankedProgrammersBuilder : IProgrammersBuilder
    {
        public IRankCalculator BuildProgrammers(IDictionary<string, IEnumerable<string>> programmerDictionary)
        {
            var programmers = programmerDictionary
                .ToDictionary(programmer => programmer.Key, programmer => new PageRankedProgrammer(programmer.Key));

            foreach (var pageRankedProgrammer in programmers.Values)
            {
                var recommendations = programmerDictionary[pageRankedProgrammer.Name];
                foreach (var recommendation in recommendations)
                {
                    pageRankedProgrammer.Recommends(programmers[recommendation]);
                }
            }

            return new RankedProgrammers(programmers.Values);
        }
    }
}