using System.Collections.Generic;

namespace ProNet
{
    public interface IRankedProgrammerBuilder
    {
        IRankedProgrammer BuildProgrammer(KeyValuePair<string, IEnumerable<string>> programmer);
    }
}