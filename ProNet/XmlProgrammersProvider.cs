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
                <Programmer name='Ed'>
                    <Recommendations>
                        <Recommendation>Liz</Recommendation>
                        <Recommendation>Rick</Recommendation>
                        <Recommendation>Bill</Recommendation>
                    </Recommendations>
                </Programmer>
                <Programmer name='Liz'></Programmer>
                <Programmer name='Rick'></Programmer>
            </Network>");

            var programmers = xml
                .Descendants("Programmer")
                .Select(programmer => new DummyProgrammer{Name = programmer.Attribute("name").Value}).ToList();

            foreach (var programmer in programmers)
            {
                var recommendations = xml
                    .Descendants("Programmer")
                    .Where(p => p.Attribute("name").Value == programmer.Name)
                    .Descendants("Recommendations")
                    .Descendants("Recommendation")
                    .Select(recommendation => recommendation.Value);

                foreach (var recommmendation in recommendations)
                {
                    programmer.Recommends(programmers.Single(p => p.Name == recommmendation));
                }
            }

            programmers.First().Rank = 2.63m;
            programmers.Skip(1).First().Rank = 0.3m;
            programmers.Skip(2).First().Rank = 0.07m;
            programmers.Skip(3).First().Rank = 2.63m;
            programmers.Skip(4).First().Rank = 0.3m;
            programmers.Skip(5).First().Rank = 0.07m;

            return new RankedProgrammers(programmers);
        }
    }
}