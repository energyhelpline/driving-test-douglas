using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammersBuilder
    {
        Programmers BuildProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> programmers, IProgrammerBuilder programmerBuilder);
    }
}