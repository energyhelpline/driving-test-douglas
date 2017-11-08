using NSubstitute;
using NUnit.Framework;

namespace ProNet.Test.Unit.ProgrammerRank
{
    [TestFixture]
    public class ProgrammerRankTests
    {
        [Test]
        public void Should_update_rank_of_ranked_programmer()
        {
            var programmer = Substitute.For<IProgrammer>();

            programmer.Rank.Returns(1m);

            var rankedProgrammers = RankedProgrammers(programmer);

            rankedProgrammers.Calculate();

            programmer
                .Received()
                .UpdateRank();
        }

        [Test]
        public void Should_update_rank_of_ranked_programmers()
        {
            var programmer1 = Substitute.For<IProgrammer>();
            var programmer2 = Substitute.For<IProgrammer>();

            programmer1.Rank.Returns(1m);
            programmer2.Rank.Returns(1m);

            var rankedProgrammers = RankedProgrammers(programmer1, programmer2);

            rankedProgrammers.Calculate();

            programmer1
                .Received()
                .UpdateRank();
            programmer2
                .Received()
                .UpdateRank();
        }

        [Test]
        public void Should_continue_to_calculate_programmer_rank_until_the_average_rank_is_1()
        {
            var programmer = Substitute.For<IProgrammer>();
            programmer.Rank.Returns(0.5m, 1m);

            var rankedProgrammers = RankedProgrammers(programmer);
            rankedProgrammers.Calculate();

            programmer
                .Received(2)
                .UpdateRank();
        }

        [Test]
        public void Should_calculate_programmer_rank_shown_in_example_1()
        {
            var programmerA = new Programmer();
            var programmerB = new Programmer();

            programmerA.Recommends(programmerB);
            programmerB.Recommends(programmerA);

            var rankedProgrammers = new Programmers(new [] {programmerA, programmerB});

            rankedProgrammers.Calculate();

            Assert.That(programmerA.Rank, Is.EqualTo(1m).Within(0.00001m));
            Assert.That(programmerB.Rank, Is.EqualTo(1m).Within(0.00001m));
        }

        [Test]
        public void Should_calculate_programmer_rank_shown_in_example_2()
        {
            var programmerA = new Programmer();
            var programmerB = new Programmer();
            var programmerC = new Programmer();
            var programmerD = new Programmer();

            programmerA.Recommends(programmerB);
            programmerA.Recommends(programmerC);
            programmerB.Recommends(programmerC);
            programmerC.Recommends(programmerA);
            programmerD.Recommends(programmerC);

            var rankedProgrammers = new Programmers(new []{programmerA, programmerB, programmerC, programmerD});

            rankedProgrammers.Calculate();

            Assert.That(programmerA.Rank, Is.EqualTo(1.49010m).Within(0.00001m));
            Assert.That(programmerB.Rank, Is.EqualTo(0.78329m).Within(0.00001m));
            Assert.That(programmerC.Rank, Is.EqualTo(1.57659m).Within(0.00001m));
            Assert.That(programmerD.Rank, Is.EqualTo(0.15m).Within(0.00001m));
        }

        private static Programmers RankedProgrammers(params IProgrammer[] programmers)
        {
            return new Programmers(programmers);
        }
    }
}
