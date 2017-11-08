using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammersFactory
    {
        IProgrammers BuildProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> rawProgrammer);
    }
}