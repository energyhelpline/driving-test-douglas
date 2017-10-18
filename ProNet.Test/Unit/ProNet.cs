using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProNet.Test.Unit
{
    [TestFixture]
    public class ProNet
    {
        [Test]
        public void Should_calculate_programmer_rank_for_two_programmers_with_a_single_recommendation()
        {
            var programmer1 = new Programmer("Dave", new List<string>{"Bill"});
            var programmer2 = new Programmer("Bill", new List<string>{"Dave"});
            programmer1.UpdateRank(new Dictionary<string, Programmer>{{programmer1.Name, programmer2}, {programmer2.Name, programmer1}});
            Assert.That(programmer1.Rank, Is.EqualTo(0.15m));
        }

        [Test]
        public void Should_calculate_the_number_of_recommendations_they_have()
        {
            var programmer = new Programmer("Dave", new List<string> { "Bill" });
            Assert.That(programmer.NumberOfRecommendations, Is.EqualTo(1));
        }
    }

    public class Programmer
    {
        private readonly List<string> _recommendations;
        private readonly string _name;

        public Programmer(string name, List<string> recommendations)
        {
            _name = name;
            _recommendations = recommendations;
        }

        public int NumberOfRecommendations => _recommendations.Count;
        public decimal Rank { get; private set; }
        public string Name => _name;

        public void UpdateRank(Dictionary<string, Programmer> programmerRanks)
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            Rank = (1m - 0.85m) + (0.85m * (programmerRanks[_recommendations.First()].Rank/programmerRanks[_recommendations.First()].NumberOfRecommendations));
        }
    }
}