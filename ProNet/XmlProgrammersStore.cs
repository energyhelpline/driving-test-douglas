using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ProNet
{
    public class XmlProgrammersStore : IProgrammersStore
    {
        private readonly IXmlLoader _xmlLoader;

        public XmlProgrammersStore(IXmlLoader xmlLoader)
        {
            _xmlLoader = xmlLoader;
        }

        public IRankCalculator GetAll()
        {
            var xml = _xmlLoader.Load();

            var programmers = xml
                .Descendants("Programmer")
                .Select(programmer => new PageRankedProgrammer(programmer.Attribute("name").Value)).ToList();

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

            return new RankedProgrammers(programmers);
        }
    }
}