using System.Collections.Generic;

namespace ProNet
{
    public interface IPageRankedProgrammerBuilder
    {
        IRankedProgrammer BuildProgrammer(KeyValuePair<string, IEnumerable<string>> programmer);
    }
}