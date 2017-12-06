using System.Linq;

namespace ProNet
{
    public class ProgrammerRank
    {
        private readonly RankedAssociation _association;

        public ProgrammerRank(RankedAssociation association)
        {
            _association = association;
        }

        public void UpdateRank()
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            _association.Rank = _association.RecommendedBys()
                .Aggregate(1m - 0.85m, (current, association) => current + 0.85m * association.Rank / association.RecommendationsCount);
        }
    }
}