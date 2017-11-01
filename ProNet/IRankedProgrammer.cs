using System.Collections.Generic;

namespace ProNet
{
    public interface IRankedProgrammer
    {
        void RecommendedBy(IRankedProgrammer programmer);
        decimal ProgrammerRankShare { get; }
        string Name { get; }
        void UpdateRank();
        decimal Rank { get; }
        IEnumerable<string> Recommendations { get; }
        void Recommends(IRankedProgrammer programmer);
    }
}