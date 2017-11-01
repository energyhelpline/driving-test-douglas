using NUnit.Framework;

namespace ProNet.Test.Unit
{
    [TestFixture]
    public class ProNetTests
    {
        [Test]
        public void Should_do_something_about_getting_the_rank_for_a_programmer_from_pro_net()
        {
            var proNet = new ProNet();
            var ranking = proNet.Rank("Nick");
            Assert.That(ranking, Is.EqualTo(2.63).Within(0.01m));
        }
    }
}