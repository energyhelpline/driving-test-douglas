using System.Collections.Generic;

namespace ProNet
{
    public class ProgrammersFactory : IProgrammersFactory
    {
        public Programmers BuildProgrammers(Dictionary<string, IProgrammer> programmers)
        {
            return new Programmers(programmers.Values);
        }
    }
}