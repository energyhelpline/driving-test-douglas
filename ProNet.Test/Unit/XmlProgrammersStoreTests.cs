using System.Linq;
using NUnit.Framework;

namespace ProNet.Test.Unit
{
    [TestFixture]
    public class XmlProgrammersStoreTests
    {
        [Test]
        public void Should_return_all_the_programmers_stored_as_xml()
        {
            var programmersStore = new XmlProgrammersStore(new HardCodedXmlLoader());
            var programmers = programmersStore.GetAll();
            var programmerA = programmers.First();
            Assert.That(programmerA.Name, Is.EqualTo("Nick"));
        }
    }
}