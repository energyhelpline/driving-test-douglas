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
        IEnumerable<string> Recommendations { get; }
        IEnumerable<string> Skills { get; }
        void Recommends(IProgrammer programmer);
    }
}