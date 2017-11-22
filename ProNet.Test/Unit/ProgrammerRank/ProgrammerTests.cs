using NUnit.Framework;

namespace ProNet.Test.Unit.ProgrammerRank
{
    [TestFixture]
    public class ProgrammerTests
    {
        [Test]
        public void Should_calculate_programmer_rank_for_a_programmer_with_a_single_recommendation()
        {
            var programmer1 = new Programmer("1", null);
            var programmer2 = new Programmer("2", null);

            programmer2.Recommends(programmer1);

            programmer1.UpdateRank();

            Assert.That(programmer1.Rank, Is.EqualTo(0.15m));
        }

        [Test]
        public void Should_calculate_the_share_of_page_rank()
        {
            var programmer1 = new Programmer("1", null);
            var programmer2 = new Programmer("2", null);
            var programmer3 = new Programmer("3", null);

            programmer2.Recommends(programmer1);
            programmer2.Recommends(programmer3);
            programmer2.Rank = 0.4m; // hopefully this will be temporary

            Assert.That(programmer2.ProgrammerRankShare, Is.EqualTo(0.2m));
        }

        [Test]
        public void Should_calculate_programmer_rank_for_a_programmer_with_multiple_recommendations()
        {
            var programmer1 = new Programmer("1", null);
            var programmer2 = new Programmer("2", null);
            var programmer3 = new Programmer("3", null);

            programmer2.Rank = 0.5m;
            programmer3.Rank = 0.25m;

            programmer2.Recommends(programmer1);
            programmer3.Recommends(programmer1);

            programmer1.UpdateRank();

            Assert.That(programmer1.Rank, Is.EqualTo(0.7875m));
        }

        [Test]
        public void Should_calculate_degrees_of_separation_for_the_programmer_to_themselves_as_0()
        {
            var programmer = new Programmer("1", null);

            var degreesOfSeparation = programmer.DegreesOfSeparation(programmer);

            Assert.That(degreesOfSeparation, Is.EqualTo(0));
        }

        [Test]
        public void Should_calculate_degrees_of_separation_for_the_programmer_from_a_programmer_they_recommended_as_1()
        {
            var programmer1 = new Programmer("1", null);
            var programmer2 = new Programmer("2", null);

            programmer1.Recommends(programmer2);

            var degreesOfSeparation = programmer1.DegreesOfSeparation(programmer2);

            Assert.That(degreesOfSeparation, Is.EqualTo(1));
        }
    }
}