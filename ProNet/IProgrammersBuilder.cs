using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammersBuilder
    {
        IRankCalculator BuildProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> programmers);
    }
}