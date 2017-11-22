using System;
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

            var toProcess = new Queue<Tuple<int, IProgrammer>>();
            toProcess.Enqueue(new Tuple<int, IProgrammer>(1, this));

            while (toProcess.Count > 0)
            {
                var programmerToProcess = toProcess.Dequeue();

                if (programmerToProcess.Item2.HasRecommended(programmer))
                    return programmerToProcess.Item1;

                if (programmerToProcess.Item2.IsRecommendedBy(programmer))
                    return programmerToProcess.Item1;
            }

            foreach (var recommendation in _recommendations)
                if (recommendation.HasRecommended(programmer))
                    return 2;

            foreach(var recommendedBy in _recommendedBy)
                if (recommendedBy.IsRecommendedBy(programmer))
                    return 2;

            return 3;
        }

        public bool HasRecommended(IProgrammer programmer)
        {
            return _recommendations.Contains(programmer);
        }

        public bool IsRecommendedBy(IProgrammer programmer)
        {
            return _recommendedBy.Contains(programmer);
        }

        public void RecommendedBy(IProgrammer programmer)
        {
            _recommendedBy.Add(programmer);
        }
    }
}
