using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammersFactory
    {
        IRankCalculator BuildProgrammers(Dictionary<string, IProgrammer> programmers);
    }
}