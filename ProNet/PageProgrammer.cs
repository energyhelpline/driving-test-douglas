﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ProNet
{
    [SuppressMessage("CodeCraft.FxCop", "TT1019:ClientSpecificInterface")]
    public class PageProgrammer : IProgrammer
    {
        private readonly string _name;
        private readonly ICollection<IProgrammer> _recommendations;
        private readonly ICollection<IProgrammer> _recommendedBy;
        private decimal _rank;

        public PageProgrammer()
        {
            _recommendations = new List<IProgrammer>();
            _recommendedBy = new List<IProgrammer>();
        }

        public PageProgrammer(string name)
        {
            _recommendations = new List<IProgrammer>();
            _recommendedBy = new List<IProgrammer>();
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

        public void Recommends(IProgrammer programmer)
        {
            _recommendations.Add(programmer);
            programmer.RecommendedBy(this);
        }

        public void RecommendedBy(IProgrammer programmer)
        {
            _recommendedBy.Add(programmer);
        }
    }
}