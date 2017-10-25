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

            var programmerRank = new ProNet.ProgrammerRank(new RankedProgrammers(new List<IRankUpdateable>{programmer}));

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
            programmer2.Rank.Returns(2m);

            var programmerRank = new ProNet.ProgrammerRank(new RankedProgrammers(new List<IRankUpdateable>{ programmer1, programmer2}));

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

            var programmerRank = new ProNet.ProgrammerRank(new RankedProgrammers(new List<IRankUpdateable>{programmer}));
            programmerRank.Calculate();

            programmer
                .Received(2)
                .UpdateRank();
        }
    }
}
