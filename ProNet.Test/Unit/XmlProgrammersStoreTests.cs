using NUnit.Framework;

namespace ProNet.Test.Unit
{
    [TestFixture]
    public class XmlProgrammersStoreTests
    {
        [Test]
        public void Programmer_should_have_a_rank_of_zero_when_first_built()
        {
            var programmersStore = new XmlProgrammersStore(new HardCodedXmlLoader(), new ProgrammersBuilder(new ProgrammerBuilder()));
            var programmers = programmersStore.GetAll();
            Assert.That(programmers.RankFor("Nick"), Is.EqualTo(0));
        }
    }
}