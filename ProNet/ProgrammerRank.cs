using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class ProgrammerRank
    {
        private decimal _rank;

        public void UpdateRank(ICollection<IProgrammer> recommendedBys)
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            Rank = recommendedBys
                .Aggregate(1m - 0.85m, (current, programmer) => current + 0.85m * programmer.ProgrammerRankShare);
        }

        public decimal ProgrammerRankShare(ICollection<IProgrammer> recommendations) => Rank / recommendations.Count;

        public decimal Rank
        {
            get => _rank;
            set => _rank = value;
        }
    }
}