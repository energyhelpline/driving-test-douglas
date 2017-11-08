using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;

namespace ProNet
{
    [SuppressMessage("CodeCraft.FxCop", "TT1020:MaxCollaboratorsRule", Scope = "type", Target = "ProNet.XmlProgrammersStore")]
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

            var recommendedProgrammers = AddRecommendations(programmers, xml);

            return BuildProgrammers(recommendedProgrammers);
        }

        private static IDictionary<string, IEnumerable<string>> AddRecommendations(IEnumerable<string> programmers, XElement xml)
        {
            return programmers
                .Select(programmer => new {
                    Programmer = programmer,
                    Recommendations = xml
                        .Descendants("Programmer")
                        .Where(p => p.Attribute("name").Value == programmer)
                        .Descendants("Recommendations")
                        .Descendants("Recommendation")
                        .Select(recommendation => recommendation.Value)})
                .ToDictionary(tuple => tuple.Programmer, tuple => tuple.Recommendations);
        }

        private static IEnumerable<string> RankedProgrammers(XElement xml)
        {
            return xml
                .Descendants("Programmer")
                .Select(programmer => programmer.Attribute("name").Value );
        }

        private static IRankCalculator BuildProgrammers(IDictionary<string, IEnumerable<string>> programmers)
        {
            var pageRankedProgrammers = new Dictionary<string, PageRankedProgrammer>();

            foreach (var programmer in programmers)
            {
                pageRankedProgrammers.Add(programmer.Key, new PageRankedProgrammer(programmer.Key));
            }

            foreach (var pageRankedProgrammer in pageRankedProgrammers.Values)
            {
                var recommendationNames = programmers[pageRankedProgrammer.Name];
                foreach (var recommendationName in recommendationNames)
                {
                    pageRankedProgrammer.Recommends(pageRankedProgrammers[recommendationName]);
                }
            }

            return new RankedProgrammers(pageRankedProgrammers.Values);
        }
    }
}