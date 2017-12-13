using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class Programmer : IProgrammer
    {
        private readonly string _name;
        private readonly ICollection<IProgrammer> _recommendations;
        private readonly ICollection<IProgrammer> _recommendedBys;
        private readonly IEnumerable<string> _skills;
        private readonly DegreesOfSeparation _degreesOfSeparation;
        private decimal _rank;

        public Programmer(string name, IEnumerable<string> skills)
        {
            _recommendations = new List<IProgrammer>();
            _recommendedBys = new List<IProgrammer>();
            _name = name;
            _skills = skills;
            _degreesOfSeparation = new DegreesOfSeparation();
        }

        public decimal Rank
        {
            get => _rank;
            get => _rank = value;
        }
        public string Name => _name;
        public IEnumerable<string> RecommendedProgrammers => _recommendations.Select(programmer => programmer.Name);
        public IEnumerable<string> Skills => _skills;

        public ICollection<IProgrammer> Recommendations => _recommendations;
        public ICollection<IProgrammer> RecommendedBys => _recommendedBys;

        public decimal ProgrammerRankShare => _rank / _recommendations.Count;

        public void UpdateRank()
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            _rank = _recommendedBys
                .Aggregate(1m - 0.85m, (current, programmer) => current + 0.85m * programmer.ProgrammerRankShare);
        }

        public void Recommends(IProgrammer programmer)
        {
            _recommendations.Add(programmer);
            programmer.RecommendedBy(this);
        }

        public void RecommendedBy(IProgrammer programmer)
        {
            _recommendedBys.Add(programmer);
        }

        public int DegreesOfSeparation(IProgrammer programmer)
        {
            return _degreesOfSeparation.Calculate(this, programmer);
        }
    }
}
