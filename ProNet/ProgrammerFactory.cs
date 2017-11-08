using System.Collections.Generic;

namespace ProNet
{
    public class ProgrammerFactory : IProgrammerFactory
    {
        public IProgrammer BuildProgrammer(KeyValuePair<string, IEnumerable<string>> programmer)
        {
            return new Programmer(programmer.Key);
        }

        public IProgrammer BuildProgrammer(string name)
        {
            return new Programmer(name);
        }
    }
}