using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class RankedProgrammers : IRankUpdater, IRankCalculator
    {
        public readonly IEnumerable<IRankedProgrammer> _programmers;

        public RankedProgrammers(IEnumerable<IRankedProgrammer> programmers)
        {
            _programmers = programmers;
        }

        public decimal AverageRank()
        {
            var totalRank = 0m;
            foreach (var programmer in _programmers)
            {
                totalRank += programmer.Rank;
            }
            return totalRank / _programmers.Count();
        }

        public void UpdateRanks()
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
    }
}