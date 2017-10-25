using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class PageRankedProgrammer
    {
        private readonly List<PageRankedProgrammer> _recommendationsGiven;
        private readonly List<PageRankedProgrammer> _recommendationsReceived;
        private decimal _rank;

        public PageRankedProgrammer()
        {
            _recommendationsGiven = new List<PageRankedProgrammer>();
            _recommendationsReceived = new List<PageRankedProgrammer>();
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

        public void Recommends(PageRankedProgrammer programmer)
        {
            _recommendationsGiven.Add(programmer);
            programmer.RecommendedBy(this);
        }

        private void RecommendedBy(PageRankedProgrammer programmer)
        {
            _recommendationsReceived.Add(programmer);
        }
    }
}