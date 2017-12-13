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
        private readonly ProgrammerRank _programmerRank;

        public Programmer(string name, IEnumerable<string> skills)
        {
            _recommendations = new List<IProgrammer>();
            _recommendedBys = new List<IProgrammer>();
            _name = name;
            _skills = skills;
            _degreesOfSeparation = new DegreesOfSeparation();
            _programmerRank = new ProgrammerRank();
        }

        public decimal Rank
        {
            get => _programmerRank.Rank;
            set => _programmerRank.Rank = value;
        }
        public string Name => _name;
        public IEnumerable<string> RecommendedProgrammers => _recommendations.Select(programmer => programmer.Name);
        public IEnumerable<string> Skills => _skills;

        public ICollection<IProgrammer> Recommendations => _recommendations;
        public ICollection<IProgrammer> RecommendedBys => _recommendedBys;

        public decimal ProgrammerRankShare => _programmerRank.ProgrammerRankShare(_recommendations);

        public void UpdateRank()
        {
            _programmerRank.UpdateRank(_recommendedBys);
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
