using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammersBuilder
    {
        IRankCalculator BuildProgrammers(IDictionary<string, IEnumerable<string>> programmers);
    }
}