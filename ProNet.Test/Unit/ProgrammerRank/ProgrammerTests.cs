using NUnit.Framework;

namespace ProNet.Test.Unit.ProgrammerRank
{
    [TestFixture]
    public class ProgrammerTests
    {
        [Test]
        public void Should_calculate_programmer_rank_for_a_programmer_with_a_single_recommendation()
        {
            var programmer1 = new Programmer("1", null, 0m);
            var programmer2 = new Programmer("2", null, 0m);

            programmer2.Recommends(programmer1);

            programmer1.UpdateRank();

            Assert.That(programmer1.Rank, Is.EqualTo(0.15m));
        }

        [Test]
        public void Should_calculate_the_share_of_page_rank()
        {
            var programmer1 = new Programmer("1", null, 0m);
            var programmer2 = new Programmer("2", null, 0.4m);
            var programmer3 = new Programmer("3", null, 0m);

            programmer2.Recommends(programmer1);
            programmer2.Recommends(programmer3);

            Assert.That(programmer2.ProgrammerRankShare, Is.EqualTo(0.2m));
        }

        [Test]
        public void Should_calculate_programmer_rank_for_a_programmer_with_multiple_recommendations()
        {
            var programmer1 = new Programmer("1", null, 0m);
            var programmer2 = new Programmer("2", null, 0.5m);
            var programmer3 = new Programmer("3", null, 0.25m);

            programmer2.Recommends(programmer1);
            programmer3.Recommends(programmer1);

            programmer1.UpdateRank();

            Assert.That(programmer1.Rank, Is.EqualTo(0.7875m));
        }

        [Test]
        public void Should_calculate_degrees_of_separation_to_themselves_as_0()
        {
            var programmer = new Programmer("1", null, 0m);

            var degreesOfSeparation = programmer.DegreesOfSeparation(programmer);

            Assert.That(degreesOfSeparation, Is.EqualTo(0));
        }

        [Test]
        public void Should_calculate_degrees_of_separation_from_a_programmer_they_recommended_as_1()
        {
            var programmer1 = new Programmer("1", null, 0m);
            var programmer2 = new Programmer("2", null, 0m);

            programmer1.Recommends(programmer2);

            var degreesOfSeparation = programmer1.DegreesOfSeparation(programmer2);

            Assert.That(degreesOfSeparation, Is.EqualTo(1));
        }

        [Test]
        public void Should_calculate_degrees_of_separation_from_a_programmer_who_recommends_them_as_1()
        {
            var programmer1 = new Programmer("1", null, 0m);
            var programmer2 = new Programmer("2", null, 0m);

            programmer2.Recommends(programmer1);

            var degressOfSeparation = programmer1.DegreesOfSeparation(programmer2);

            Assert.That(degressOfSeparation, Is.EqualTo(1));
        }

        [Test]
        public void Should_calculate_degrees_of_separation_from_a_programmer_a_recommendation_has_recommended_as_2()
        {
            var programmer3 = new Programmer("3", null, 0m);
            var programmer1 = new Programmer("1", null, 0m);
            var programmer2 = new Programmer("2", null, 0m);

            programmer1.Recommends(programmer2);
            programmer2.Recommends(programmer3);

            var degressOfSeparation = programmer1.DegreesOfSeparation(programmer3);

            Assert.That(degressOfSeparation, Is.EqualTo(2));
        }

        [Test]
        public void Should_calculate_second_degree_recommendations_received()
        {
            var programmer3 = new Programmer("3", null, 0m);
            var programmer1 = new Programmer("1", null, 0m);
            var programmer2 = new Programmer("2", null, 0m);

            programmer3.Recommends(programmer2);
            programmer2.Recommends(programmer1);

            var degreesOfSeparation = programmer1.DegreesOfSeparation(programmer3);

            Assert.That(degreesOfSeparation, Is.EqualTo(2));
        }

        [Test]
        public void Should_return_lowest_calculated_degree_of_separation()
        {
            var programmer1 = new Programmer("1", null, 0m);
            var programmer2 = new Programmer("2", null, 0m);
            var programmer3 = new Programmer("3", null, 0m);
            var programmer4 = new Programmer("4", null, 0m);
            var programmer5 = new Programmer("5", null, 0m);

            programmer1.Recommends(programmer3);
            programmer2.Recommends(programmer1);
            programmer3.Recommends(programmer2);
            programmer4.Recommends(programmer2);
            programmer5.Recommends(programmer3);

            var degreeOfSeparation = programmer1.DegreesOfSeparation(programmer5);
            Assert.That(degreeOfSeparation, Is.EqualTo(2));
        }

        [Test]
        public void Should_calculate_degree_of_separation_within_network_with_circular_reference()
        {
            var programmer1 = new Programmer("1", null, 0m);
            var programmer2 = new Programmer("2", null, 0m);
            var programmer3 = new Programmer("3", null, 0m);
            var programmer4 = new Programmer("4", null, 0m);
            var programmer5 = new Programmer("5", null, 0m);

            programmer1.Recommends(programmer2);
            programmer2.Recommends(programmer3);
            programmer3.Recommends(programmer1);
            programmer3.Recommends(programmer4);
            programmer4.Recommends(programmer5);

            var degreeOfSeparation = programmer1.DegreesOfSeparation(programmer5);

            Assert.That(degreeOfSeparation, Is.EqualTo(3));
        }
    }
}