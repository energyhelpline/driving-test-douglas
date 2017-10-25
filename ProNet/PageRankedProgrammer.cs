using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ProNet
{
    [SuppressMessage("CodeCraft.FxCop", "TT1019:ClientSpecificInterface")]
    public class PageRankedProgrammer : IRankedProgrammer
    {
        private readonly List<IRankedProgrammer> _recommends;
        private readonly List<IRankedProgrammer> _recommendedBy;
        private decimal _rank;

        public PageRankedProgrammer()
        {
            _recommends = new List<IRankedProgrammer>();
            _recommendedBy = new List<IRankedProgrammer>();
        }

        public decimal Rank
        {
            get => _rank;
            set => _rank = value;
        }

        public decimal ProgrammerRankShare => _rank / _recommends.Count();

        public void UpdateRank()
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            _rank = _recommendedBy
                .Aggregate(1m - 0.85m, (current, programmer) => current + 0.85m * programmer.ProgrammerRankShare);
        }

        public void Recommends(IRankedProgrammer programmer)
        {
            _recommends.Add(programmer);
            programmer.RecommendedBy(this);
        }

        public void RecommendedBy(IRankedProgrammer programmer)
        {
            _recommendedBy.Add(programmer);
        }
    }

    public interface IRankedProgrammer
    {
        void RecommendedBy(IRankedProgrammer programmer);
        decimal ProgrammerRankShare { get; }
    }
}
