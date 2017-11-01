using NUnit.Framework;

namespace ProNet.Test.Unit
{
    [TestFixture]
    public class ProNetTests
    {
        [Test]
        public void Should_return_the_rank_for_programmer_by_programmer_name()
        {
            var proNet = new ProNet(new ProgrammersProvider());
            var ranking = proNet.Rank("Nick");
            Assert.That(ranking, Is.EqualTo(2.63).Within(0.01m));
        }
    }
}