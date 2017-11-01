using System.Collections.Generic;
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
            var programmer = Substitute.For<IRankUpdateable>();

            programmer.Rank.Returns(1m);

            var programmerRank = ProgrammerRank(RankedProgrammers(programmer));

            programmerRank.Calculate();

            programmer
                .Received()
                .UpdateRank();
        }

        [Test]
        public void Should_update_rank_of_ranked_programmers()
        {
            var programmer1 = Substitute.For<IRankUpdateable>();
            var programmer2 = Substitute.For<IRankUpdateable>();

            programmer1.Rank.Returns(1m);
            programmer2.Rank.Returns(1m);

            var programmerRank = ProgrammerRank(RankedProgrammers(programmer1, programmer2));

            programmerRank.Calculate();

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
            var programmer = Substitute.For<IRankUpdateable>();
            programmer.Rank.Returns(0.5m, 1m);

            var programmerRank = ProgrammerRank(RankedProgrammers(programmer));
            programmerRank.Calculate();

            programmer
                .Received(2)
                .UpdateRank();
        }

        [Test]
        public void Should_calculate_programmer_rank_shown_in_example_1()
        {
            var programmerA = new PageRankedProgrammer();
            var programmerB = new PageRankedProgrammer();

            programmerA.Recommends(programmerB);
            programmerB.Recommends(programmerA);

            var rankedProgrammers = new RankedProgrammers(new [] {programmerA, programmerB});

            var programmerRank = new ProNet.ProgrammerRank(rankedProgrammers);

            programmerRank.Calculate();

            Assert.That(programmerA.Rank, Is.EqualTo(1m).Within(0.00001m));
            Assert.That(programmerB.Rank, Is.EqualTo(1m).Within(0.00001m));
        }

        private static ProNet.ProgrammerRank ProgrammerRank(RankedProgrammers newRankedProgrammers)
        {
            return new ProNet.ProgrammerRank(newRankedProgrammers);
        }

        private static RankedProgrammers RankedProgrammers(params IRankUpdateable[] programmers)
        {
            return new RankedProgrammers(programmers);
        }
    }
}
