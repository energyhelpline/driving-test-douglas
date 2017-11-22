using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammerFactory
    {
        IProgrammer BuildProgrammer(string name, IEnumerable<string> skills);
    }
}