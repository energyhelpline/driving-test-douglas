using System.Collections.Generic;

namespace ProNet
{
    public class ProgrammersBuilder : IProgrammersBuilder
    {
        public Programmers BuildProgrammers(Dictionary<string, IProgrammer> programmers)
        {
            return new Programmers(programmers.Values);
        }
    }
}