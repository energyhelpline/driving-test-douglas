using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammerFactory
    {
        IProgrammer BuildProgrammer(KeyValuePair<string, IEnumerable<string>> programmer);
    }
}