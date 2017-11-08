using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammersFactory
    {
        Programmers BuildProgrammers(Dictionary<string, IProgrammer> programmers);
    }
}