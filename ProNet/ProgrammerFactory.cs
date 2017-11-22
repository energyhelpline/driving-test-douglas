using System.Collections.Generic;

namespace ProNet
{
    public class ProgrammerFactory : IProgrammerFactory
    {
        public IProgrammer BuildProgrammer(string name, IEnumerable<string> skills)
        {
            return new Programmer(name, skills);
        }
    }
}