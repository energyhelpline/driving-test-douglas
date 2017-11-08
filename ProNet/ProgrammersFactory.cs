using System.Collections.Generic;

namespace ProNet
{
    public class ProgrammersFactory : IProgrammersFactory
    {
        public IRankCalculator BuildProgrammers(Dictionary<string, IProgrammer> programmers)
        {
            return new Programmers(programmers.Values);
        }
    }
}