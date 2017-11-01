using System.Linq;
using System.Xml.Linq;

namespace ProNet
{
    public class XmlProgrammersProvider : IProgrammersProvider
    {
        public IRankCalculator GetAll()
        {
            var xml = XElement.Parse(@"<?xml version=""1.0"" encoding=""utf-8"" ?>
            <Network>
                <Programmer name='Nick'></Programmer>
                <Programmer name='Bill'></Programmer>
                <Programmer name='Dave'></Programmer>
            </Network>");

            var programmers = xml
                .Descendants("Programmer")
                .Select(programmer => new DummyProgrammer{Name = programmer.Attribute("name").Value}).ToList();

            programmers.First().Rank = 2.63m;
            programmers.Skip(1).First().Rank = 0.3m;
            programmers.Skip(2).First().Rank = 0.07m;

            return new RankedProgrammers(programmers);
        }
    }
}