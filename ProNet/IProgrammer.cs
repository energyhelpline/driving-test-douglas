using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammer
    {
        void RecommendedBy(IProgrammer programmer);
        string Name { get; }
        void UpdateRank();
        decimal Rank { get; }
        IEnumerable<string> RecommendedProgrammers { get; }
        IEnumerable<string> Skills { get; }
        Association Association { get; }
        RankedAssociation RankedAssociation { get; }
        NamedAssociation NamedAssociation { get; }
        void Recommends(IProgrammer programmer);
        int DegreesOfSeparation(IProgrammer name);
    }
}