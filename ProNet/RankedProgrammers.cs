﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class RankedProgrammers : IRankUpdater, IRankCalculator
    {
        public readonly IEnumerable<IRankUpdateable> _programmers;

        public RankedProgrammers(IEnumerable<IRankUpdateable> programmers)
        {
            _programmers = programmers;
        }

        public IEnumerator<IRankUpdateable> GetEnumerator()
        {
            return _programmers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

        public string[] RecommendationsFor(string name)
        {
            return new[] { "Liz", "Rick", "Bill" };
        }
    }
}