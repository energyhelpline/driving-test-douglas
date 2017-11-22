using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class Programmer : IProgrammer
    {
        private readonly string _name;
        private readonly ICollection<IProgrammer> _recommendations;
        private readonly ICollection<IProgrammer> _recommendedBy;
        private readonly IEnumerable<string> _skills;
        private decimal _rank;

        public Programmer(string name, IEnumerable<string> skills)
        {
            _recommendations = new List<IProgrammer>();
            _recommendedBy = new List<IProgrammer>();
            _name = name;
            _skills = skills;
        }

        public decimal Rank
        {
            get => _rank;
            set => _rank = value;
        }

        public string Name => _name;

        public IEnumerable<string> Recommendations => _recommendations.Select(programmer => programmer.Name);

        public IEnumerable<string> Skills => _skills;

        public decimal ProgrammerRankShare => _rank / _recommendations.Count();

        public void UpdateRank()
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            _rank = _recommendedBy
                .Aggregate(1m - 0.85m, (current, programmer) => current + 0.85m * programmer.ProgrammerRankShare);
        }

        public void Recommends(IProgrammer programmer)
        {
            _recommendations.Add(programmer);
            programmer.RecommendedBy(this);
        }

        public int DegreesOfSeparation(IProgrammer programmer)
        {
            if (this == programmer)
                return 0;

            if (_recommendations.Contains(programmer))
                return 1;

            if (_recommendedBy.Contains(programmer))
                return 1;

            foreach (var recommendation in _recommendations)
                if (recommendation.HasRecommended(programmer))
                    return 2;

            return 3;
        }

        public bool HasRecommended(IProgrammer programmer)
        {
            return _recommendations.Contains(programmer);
        }

        public void RecommendedBy(IProgrammer programmer)
        {
            _recommendedBy.Add(programmer);
        }
    }
}
