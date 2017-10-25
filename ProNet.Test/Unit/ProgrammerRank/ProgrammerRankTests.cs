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

            var programmerRank = new ProgrammerRank(programmer);

            programmerRank.Calculate();

            programmer
                .Received()
                .UpdateRank();
        }

        // something about a collection of rankedProgrammers
        // something about looping through that collection updating their ranks
        // something about keeping looping until the average is 1
    }

    public class ProgrammerRank
    {
        private readonly IRankUpdateable _programmer;

        public ProgrammerRank(IRankUpdateable programmer)
        {
            _programmer = programmer;
        }

        public void Calculate()
        {
            _programmer.UpdateRank();
        }
    }
}
