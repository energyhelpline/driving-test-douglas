using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammersBuilder
    {
        RankedProgrammers BuildProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> programmers, IRankedProgrammerBuilder rankedProgrammerBuilder);
    }
}