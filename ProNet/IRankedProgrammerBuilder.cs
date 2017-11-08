using System.Collections.Generic;

namespace ProNet
{
    public interface IRankedProgrammerBuilder
    {
        IProgrammer BuildProgrammer(KeyValuePair<string, IEnumerable<string>> programmer);
    }
}