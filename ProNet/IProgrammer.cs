using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammer : IRankUpdateable, IAssociation
    {
        string Name { get; }
        IEnumerable<string> RecommendedProgrammers { get; }
        IEnumerable<string> Skills { get; }
        void RecommendedBy(IProgrammer programmer);
        void Recommends(IProgrammer programmer);
    }
}