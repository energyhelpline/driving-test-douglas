﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProNet.Test.Unit
{
    [TestFixture]
    public class ProNet
    {
        [Test]
        public void Should_calculate_programmer_rank()
        {
            var programmer1 = new Programmer("Dave", new List<string>{"Bill"});
            var programmer2 = new Programmer("Bill", new List<string>{"Dave"});
            programmer1.UpdateRank(new Dictionary<string, Tuple<decimal, int>>{{"Bill", new Tuple<decimal,int>(programmer2.Rank, programmer2.NumberOfRecommendations)}, {"Dave", new Tuple<decimal, int>(programmer1.Rank, programmer1.NumberOfRecommendations)}});
            Assert.That(programmer1.Rank, Is.EqualTo(0.15m));
        }

        [Test]
        public void Should_calculate_the_number_of_recommendations_they_have()
        {
            var programmer = new Programmer("Dave", new List<string> {"Bill"});
            Assert.That(programmer.NumberOfRecommendations, Is.EqualTo(1));
        }
    }

    public class Programmer
    {
        private readonly List<string> _recommendations;
        private readonly string _name;
        public decimal Rank { get; private set; }

        public Programmer(string name, List<string> recommendations)
        {
            _recommendations = recommendations;
        }

        public int NumberOfRecommendations => _recommendations.Count;

        public void UpdateRank(Dictionary<string, Tuple<decimal, int>> programmerRanks)
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            Rank = (1m - 0.85m) + (0.85m * (programmerRanks[_recommendations.First()].Item1/programmerRanks[_recommendations.First()].Item2));
        }
    }
}