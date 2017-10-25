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

            var programmerRank = new ProgrammerRank(new List<IRankUpdateable>{programmer});

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

            var programmerRank = new ProgrammerRank(new List<IRankUpdateable>{ programmer1, programmer2});

            programmerRank.Calculate();

            programmer1
                .Received()
                .UpdateRank();
            programmer2
                .Received()
                .UpdateRank();
        }

        // something about a collection of rankedProgrammers
        // something about looping through that collection updating their ranks
        // something about keeping looping until the average is 1
    }

    public class ProgrammerRank
    {
        private readonly List<IRankUpdateable> _programmers;

        public ProgrammerRank(List<IRankUpdateable> programmers)
        {
            _programmers = programmers;
        }

        public void Calculate()
        {
            foreach (var programmer in _programmers)
            {
                programmer.UpdateRank();
            }
        }
    }
}
