using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class PageRankedProgrammer : IRankedProgrammer
    {
        private readonly List<IRankedProgrammer> _recommendationsGiven;
        private readonly List<IRankedProgrammer> _recommendationsReceived;
        private decimal _rank;

        public PageRankedProgrammer()
        {
            _recommendationsGiven = new List<IRankedProgrammer>();
            _recommendationsReceived = new List<IRankedProgrammer>();
        }

        public decimal Rank
        {
            get => _rank;
            set => _rank = value;
        }

        public decimal ProgrammerRankShare => _rank / _recommendationsGiven.Count();

        public void UpdateRank()
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            _rank = _recommendationsReceived
                .Aggregate(1m - 0.85m, (current, programmer) => current + 0.85m * programmer.ProgrammerRankShare);
        }

        public void Recommends(IRankedProgrammer programmer)
        {
            _recommendationsGiven.Add(programmer);
            programmer.RecommendedBy(this);
        }

        public void RecommendedBy(IRankedProgrammer programmer)
        {
            _recommendationsReceived.Add(programmer);
        }
    }

    public interface IRankedProgrammer
    {
        void RecommendedBy(IRankedProgrammer programmer);
        decimal ProgrammerRankShare { get; }
    }
}