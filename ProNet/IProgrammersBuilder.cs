using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammersBuilder
    {
        Programmers BuildProgrammers(Dictionary<string, IProgrammer> programmers);
    }
}