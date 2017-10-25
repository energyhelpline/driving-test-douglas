using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProNet.Test.Unit
{
    [TestFixture]
    public class ProgrammerTests
    {
        [Test]
        public void Should_calculate_programmer_rank_for_a_programmer_with_a_single_recommendation()
        {
            var programmer1 = new Programmer("Dave");
            var programmer2 = new Programmer("Bill");

            programmer1.IsRecommendedBy(programmer2);
            programmer2.Recommends(programmer1);

            programmer1.UpdateRank();

            Assert.That(programmer1.Rank, Is.EqualTo(0.15m));
        }

        [Test]
        public void Should_calculate_the_number_of_recommendations_they_have()
        {
            var programmer1 = new Programmer("Dave");
            var programmer2 = new Programmer("Bill");

            programmer1.Recommends(programmer2);

            Assert.That(programmer1.RecommendationsGivenCount, Is.EqualTo(1));
        }

        [Test]
        public void Should_calculate_the_share_of_page_rank()
        {
            var programmer1 = new Programmer("Programmer1");
            var programmer2 = new Programmer("Programmer2");
            var programmer3 = new Programmer("Programmer3");

            programmer2.Recommends(programmer1);
            programmer2.Recommends(programmer3);
            programmer2.Rank = 0.4m; // hopefully this will be temporary

            Assert.That(programmer2.ProgrammerRankShare, Is.EqualTo(0.2m));
        }
    }

    public class Programmer
    {
        private readonly string _name;
        private readonly List<Programmer> _recommendationsGiven;
        private readonly List<Programmer> _recommendationsReceived;
        private decimal _rank;

        public Programmer(string name)
        {
            _name = name;
            _recommendationsGiven = new List<Programmer>();
            _recommendationsReceived = new List<Programmer>();
        }

        public int RecommendationsGivenCount => _recommendationsGiven.Count;
        public decimal Rank
        {
            get => _rank;
            set => _rank = value;
        }
        public string Name => _name;
        public decimal ProgrammerRankShare => _rank / _recommendationsGiven.Count();

        public void UpdateRank()
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            _rank = (1m - 0.85m) + (0.85m * (_recommendationsReceived.First().Rank/_recommendationsReceived.First().RecommendationsGivenCount));
        }

        public void Recommends(Programmer programmer)
        {
            _recommendationsGiven.Add(programmer);
        }

        public void IsRecommendedBy(Programmer programmer)
        {
            _recommendationsReceived.Add(programmer);
        }
    }
}