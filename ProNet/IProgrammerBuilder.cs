using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammerBuilder
    {
        IProgrammer BuildProgrammer(KeyValuePair<string, IEnumerable<string>> programmer);
    }
}