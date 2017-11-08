using System.Collections.Generic;

namespace ProNet
{
    public class PageRankedProgrammerBuilder : IPageRankedProgrammerBuilder
    {
        public IRankedProgrammer BuildProgrammer(KeyValuePair<string, IEnumerable<string>> programmer)
        {
            return new PageRankedProgrammer(programmer.Key);
        }
    }
}