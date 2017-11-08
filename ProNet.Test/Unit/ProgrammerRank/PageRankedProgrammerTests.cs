﻿using NUnit.Framework;

namespace ProNet.Test.Unit.ProgrammerRank
{
    [TestFixture]
    public class PageRankedProgrammerTests
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

        [Test]
        public void Should_calculate_programmer_rank_for_a_programmer_with_multiple_recommendations()
        {
            var programmer1 = new Programmer();
            var programmer2 = new Programmer();
            var programmer3 = new Programmer();

            programmer2.Rank = 0.5m;
            programmer3.Rank = 0.25m;

            programmer2.Recommends(programmer1);
            programmer3.Recommends(programmer1);

            programmer1.UpdateRank();

            Assert.That(programmer1.Rank, Is.EqualTo(0.7875m));
        }
    }
}