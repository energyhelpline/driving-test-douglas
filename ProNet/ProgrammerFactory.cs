using System.Collections.Generic;

namespace ProNet
{
    public class ProgrammerFactory : IProgrammerFactory
    {
        public IProgrammer BuildProgrammer(KeyValuePair<string, IEnumerable<string>> programmer)
        {
            return new PageProgrammer(programmer.Key);
        }
    }
}