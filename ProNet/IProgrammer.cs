using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammer
    {
        void RecommendedBy(IProgrammer programmer);
        decimal ProgrammerRankShare { get; }
        string Name { get; }
        void UpdateRank();
        decimal Rank { get; }
        IEnumerable<string> RecommendedProgrammers { get; }
        IEnumerable<string> Skills { get; }
        ICollection<IProgrammer> Recommendations { get; }
        ICollection<IProgrammer> RecommendedBys { get; }
        void Recommends(IProgrammer programmer);
        int DegreesOfSeparation(IProgrammer name);
    }
}