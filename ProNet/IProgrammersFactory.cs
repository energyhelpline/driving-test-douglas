using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammersFactory
    {
        IProgrammers BuildProgrammers(Dictionary<string, IProgrammer> programmers);
    }
}