using System.Collections.Generic;

namespace ProNet
{
    public class RankedProgrammersBuilder : IProgrammersBuilder
    {
        public IRankCalculator BuildProgrammers(IDictionary<string, IEnumerable<string>> programmers)
        {
            var pageRankedProgrammers = new Dictionary<string, PageRankedProgrammer>();

            foreach (var programmer in programmers)
            {
                pageRankedProgrammers.Add(programmer.Key, new PageRankedProgrammer(programmer.Key));
            }

            foreach (var pageRankedProgrammer in pageRankedProgrammers.Values)
            {
                var recommendationNames = programmers[pageRankedProgrammer.Name];
                foreach (var recommendationName in recommendationNames)
                {
                    pageRankedProgrammer.Recommends(pageRankedProgrammers[recommendationName]);
                }
            }

            return new RankedProgrammers(pageRankedProgrammers.Values);
        }
    }
}