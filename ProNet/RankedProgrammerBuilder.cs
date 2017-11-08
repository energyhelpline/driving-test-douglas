using System.Collections.Generic;

namespace ProNet
{
    public class RankedProgrammerBuilder : IRankedProgrammerBuilder
    {
        public IRankedProgrammer BuildProgrammer(KeyValuePair<string, IEnumerable<string>> programmer)
        {
            return new PageRankedProgrammer(programmer.Key);
        }
    }
}