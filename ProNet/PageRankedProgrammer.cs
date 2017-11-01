using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ProNet
{
    [SuppressMessage("CodeCraft.FxCop", "TT1019:ClientSpecificInterface")]
    public class PageRankedProgrammer : IRankedProgrammer
    {
        private readonly string _name;
        private readonly ICollection<IRankedProgrammer> _recommendations;
        private readonly ICollection<IRankedProgrammer> _recommendedBy;
        private decimal _rank;

        public PageRankedProgrammer()
        {
            _recommendations = new List<IRankedProgrammer>();
            _recommendedBy = new List<IRankedProgrammer>();
        }

        public PageRankedProgrammer(string name)
        {
            _recommendations = new List<IRankedProgrammer>();
            _recommendedBy = new List<IRankedProgrammer>();
            _name = name;
        }

        public decimal Rank
        {
            get => _rank;
            set => _rank = value;
        }

        public string Name => _name;

        public IEnumerable<string> Recommendations => _recommendations.Select(programmer => programmer.Name);

        public decimal ProgrammerRankShare => _rank / _recommendations.Count();

        public void UpdateRank()
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            _rank = _recommendedBy
                .Aggregate(1m - 0.85m, (current, programmer) => current + 0.85m * programmer.ProgrammerRankShare);
        }

        public void Recommends(IRankedProgrammer programmer)
        {
            _recommendations.Add(programmer);
            programmer.RecommendedBy(this);
        }

        public void RecommendedBy(IRankedProgrammer programmer)
        {
            _recommendedBy.Add(programmer);
        }
    }
}
