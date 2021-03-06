﻿using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class Programmers : IProgrammers
    {
        public readonly IEnumerable<IProgrammer> _programmers;

        public Programmers(List<IProgrammer> programmers)
        {
            _programmers = programmers;
        }

        public void Calculate()
        {
            do
                UpdateRanks();
            while (1 - AverageRank() >= 0.000001m);
        }

        public decimal RankFor(string name)
        {
            return GetByName(name).Rank;
        }

        public IEnumerable<string> RecommendationsFor(string name)
        {
            return GetByName(name).RecommendedProgrammers;
        }

        public IEnumerable<string> Skills(string programmer)
        {
            return GetByName(programmer).Skills;
        }

        public int DegreesOfSeparation(string programmer1, string programmer2)
        {
            return GetByName(programmer1).DegreesOfSeparation(GetByName(programmer2));
        }

        public void AddRecommendation(string recommender, string recommendation)
        {
            GetByName(recommender).Recommends(GetByName(recommendation));
        }

        private IProgrammer GetByName(string name)
        {
            return _programmers.Single(programmer => programmer.Name == name);
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
    }
}