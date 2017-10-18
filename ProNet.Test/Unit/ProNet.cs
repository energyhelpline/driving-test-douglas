using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ProNet.Test.Unit
{
    [TestFixture]
    public class ProNet
    {
        [Test]
        public void Should_calculate_programmer_rank()
        {
            var programmer = new Programmer("Dave", "Bill");
            var programmerRank = programmer.Rank(new Dictionary<string, Tuple<decimal, int>>{{"Bill", new Tuple<decimal,int>(0m, 1)}, {"Dave", new Tuple<decimal, int>(0m, 1)}});
            Assert.That(programmerRank, Is.EqualTo(0.15m));
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
        private readonly string _recommendation;

        public Programmer(string name, string recommendation)
        {
            _name = name;
            _recommendation = recommendation;
        }

        public Programmer(string name, List<string> recommendations)
        {
            _recommendations = recommendations;
        }

        public int NumberOfRecommendations => _recommendations.Count;

        public decimal Rank(Dictionary<string, Tuple<decimal, int>> programmerRanks)
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            return (1m - 0.85m) + (0.85m * (programmerRanks[_recommendation].Item1/programmerRanks[_recommendation].Item2));
        }
    }
}