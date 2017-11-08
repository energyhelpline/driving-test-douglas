using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class Programmers : IProgrammers
    {
        public readonly IEnumerable<IProgrammer> _programmers;

        public Programmers(IEnumerable<IProgrammer> programmers)
        {
            _programmers = programmers;
        }

        private decimal AverageRank()
        {
            var totalRank = 0m;
            foreach (var programmer in _programmers)
            {
                totalRank += programmer.Rank;
            }
            return totalRank / _programmers.Count();
        }

        private void UpdateRanks()
        {
            foreach (var programmer in _programmers)
            {
                programmer.UpdateRank();
            }
        }

        public void Calculate()
        {
            do
                UpdateRanks();
            while (1 - AverageRank() >= 0.000001m);
        }

        public decimal RankFor(string name)
        {
            return _programmers.Single(programmer => programmer.Name == name).Rank;
        }

        public IEnumerable<string> RecommendationsFor(string name)
        {
            return _programmers.Single(programmer => programmer.Name == name).Recommendations;
        }

        public void AddRecommendation(string recommender, string recommendation)
        {
            GetByName(recommender).Recommends(GetByName(recommendation));
        }

        private IProgrammer GetByName(string name)
        {
            return _programmers.Single(programmer => programmer.Name == name);
        }
    }
}