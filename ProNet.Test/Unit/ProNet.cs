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
            var programmer1 = new Programmer("Dave");
            var programmer2 = new Programmer("Bill");

            programmer1.Recommends(programmer2);
            programmer1.IsRecommendedBy(programmer2);

            programmer2.Recommends(programmer1);
            programmer2.IsRecommendedBy(programmer1);

            programmer1.UpdateRank();

            Assert.That(programmer1.Rank, Is.EqualTo(0.15m));
        }

        [Test]
        public void Should_calculate_the_number_of_recommendations_they_have()
        {
            var programmer1 = new Programmer("Dave");
            var programmer2 = new Programmer("Bill");

            programmer1.Recommends(programmer2);

            Assert.That(programmer1.NumberOfRecommendations, Is.EqualTo(1));
        }
    }

    public class Programmer
    {
        private readonly string _name;
        private readonly List<Programmer> _recommends;
        private readonly List<Programmer> _isRecommendedBy;
        private decimal _rank;

        public Programmer(string name)
        {
            _name = name;
            _recommends = new List<Programmer>();
            _isRecommendedBy = new List<Programmer>();
        }

        public int NumberOfRecommendations => _recommends.Count;
        public decimal Rank => _rank;
        public string Name => _name;

        public void UpdateRank()
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            _rank = (1m - 0.85m) + (0.85m * (_isRecommendedBy.First().Rank/_isRecommendedBy.First()._recommends.Count));
        }

        public void Recommends(Programmer programmer)
        {
            _recommends.Add(programmer);
        }

        public void IsRecommendedBy(Programmer programmer)
        {
            _isRecommendedBy.Add(programmer);
        }
    }
}