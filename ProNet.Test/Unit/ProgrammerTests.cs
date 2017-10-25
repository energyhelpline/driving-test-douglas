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
            var programmer1 = new Programmer();
            var programmer2 = new Programmer();

            programmer2.Recommends(programmer1);

            programmer1.UpdateRank();

            Assert.That(programmer1.Rank, Is.EqualTo(0.15m));
        }

        [Test]
        public void Should_calculate_the_share_of_page_rank()
        {
            var programmer1 = new Programmer();
            var programmer2 = new Programmer();
            var programmer3 = new Programmer();

            programmer2.Recommends(programmer1);
            programmer2.Recommends(programmer3);
            programmer2.Rank = 0.4m; // hopefully this will be temporary

            Assert.That(programmer2.ProgrammerRankShare, Is.EqualTo(0.2m));
        }
    }

    public class Programmer
    {
        private readonly List<Programmer> _recommendationsGiven;
        private decimal _rank;

        public Programmer()
        {
            _recommendationsGiven = new List<Programmer>();
        }

        public decimal Rank
        {
            get => _rank;
            set => _rank = value;
        }

        public decimal ProgrammerRankShare => _rank / _recommendationsGiven.Count();

        public void UpdateRank()
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            _rank = (1m - 0.85m) + (0.85m * (0));
        }

        public void Recommends(Programmer programmer)
        {
            _recommendationsGiven.Add(programmer);
        }
    }
}