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

        public Programmer(string name, IEnumerable<string> skills, decimal rank)
        {
            _recommendations = new List<IProgrammer>();
            _recommendedBys = new List<IProgrammer>();
            _name = name;
            _skills = skills;
            _rank = rank;
            _degreesOfSeparation = new DegreesOfSeparation();
        }

        public decimal Rank => _rank;
        public string Name => _name;
        public IEnumerable<string> RecommendedProgrammers => _recommendations.Select(programmer => programmer.Name);
        public IEnumerable<string> Skills => _skills;

        public decimal ProgrammerRankShare => _rank / _recommendations.Count;

        public void UpdateRank()
        {
            IEnumerable<IRankUpdateable> recommendedBys = _recommendedBys;
            _rank = recommendedBys
                .Aggregate(1m - 0.85m, (current, programmer) => current + 0.85m * programmer.ProgrammerRankShare);
        }

        public int DegreesOfSeparation(IAssociation programmer)
        {
            return _degreesOfSeparation.Calculate(this, programmer);
        }

        public bool HasRecommended(IAssociation programmer)
        {
            return _recommendations.Contains(programmer);
        }

        public bool IsRecommendedBy(IAssociation programmer)
        {
            return _recommendedBys.Contains(programmer);
        }

        public void AddRecommendationsTo(DegreesOfSeparation degreesOfSeparation)
        {
            degreesOfSeparation.AddToQueue(_recommendations);
        }

        public void AddRecommendedBysTo(DegreesOfSeparation degreesOfSeparation)
        {
            degreesOfSeparation.AddToQueue(_recommendedBys);
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
    }
}
