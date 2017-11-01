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

            var programmers = RankedProgrammers(xml);

            programmers = AddRecommendations(programmers, xml);

            return BuildProgrammers(programmers);
        }

        private static List<IRankedProgrammer> AddRecommendations(List<IRankedProgrammer> programmers, XElement xml)
        {
            foreach (var programmer in programmers)
            {
                var recommendations = xml
                    .Descendants("Programmer")
                    .Where(p => p.Attribute("name").Value == programmer.Name)
                    .Descendants("Recommendations")
                    .Descendants("Recommendation")
                    .Select(recommendation => recommendation.Value);

                AddRecommendations(recommendations, programmer, programmers);
            }

            return programmers;
        }

        private static List<IRankedProgrammer> RankedProgrammers(XElement xml)
        {
            return xml
                .Descendants("Programmer")
                .Select(BuildProgrammer).ToList();
        }

        private static void AddRecommendations(IEnumerable<string> recommendations, IRankedProgrammer programmer, List<IRankedProgrammer> programmers)
        {
            foreach (var recommmendation in recommendations)
            {
                programmer.Recommends(programmers.Single(p => p.Name == recommmendation));
            }
        }

        private static IRankCalculator BuildProgrammers(List<IRankedProgrammer> programmers)
        {
            return new RankedProgrammers(programmers);
        }

        private static IRankedProgrammer BuildProgrammer(XElement programmer)
        {
            return new PageRankedProgrammer(programmer.Attribute("name").Value);
        }
    }
}