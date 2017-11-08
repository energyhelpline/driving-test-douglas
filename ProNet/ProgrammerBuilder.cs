using System.Collections.Generic;

namespace ProNet
{
    public class ProgrammerBuilder : IProgrammerBuilder
    {
        public IProgrammer BuildProgrammer(KeyValuePair<string, IEnumerable<string>> programmer)
        {
            return new PageProgrammer(programmer.Key);
        }
    }
}