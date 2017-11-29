﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class Programmer : IProgrammer
    {
        private readonly string _name;
        public readonly ICollection<IProgrammer> _recommendations;
        public readonly ICollection<IProgrammer> _recommendedBy;
        private readonly IEnumerable<string> _skills;
        private decimal _rank;
        private readonly DegreesOfSeparation _degreesOfSeparation;

        public Programmer(string name, IEnumerable<string> skills)
        {
            _recommendations = new List<IProgrammer>();
            _recommendedBy = new List<IProgrammer>();
            _name = name;
            _skills = skills;
            _degreesOfSeparation = new DegreesOfSeparation();
        }

        public decimal Rank
        {
            get => _rank;
            set => _rank = value;
        }

        public ICollection<IProgrammer> _Recommendations => _recommendations;
        public ICollection<IProgrammer> _RecommendedBy => _recommendedBy;

        public string Name => _name;

        public IEnumerable<string> Recommendations => _recommendations.Select(programmer => programmer.Name);

        public IEnumerable<string> Skills => _skills;

        public decimal ProgrammerRankShare => _rank / _recommendations.Count();

        public DegreesOfSeparation DegreesOfSeparation1
        {
            get { return _degreesOfSeparation; }
        }

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
            return _degreesOfSeparation.Calculate(this, programmer);
        }

        public void RecommendedBy(IProgrammer programmer)
        {
            _recommendedBy.Add(programmer);
        }
    }

    public class ProgrammersNotConnectedException : Exception
    {
    }
}
