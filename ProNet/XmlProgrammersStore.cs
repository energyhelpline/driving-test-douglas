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
        private readonly IProgrammersBuilder _rankedProgrammersBuilder;

        public XmlProgrammersStore(IXmlLoader xmlLoader, IProgrammersBuilder rankedProgrammersBuilder)
        {
            _xmlLoader = xmlLoader;
            _rankedProgrammersBuilder = rankedProgrammersBuilder;
        }

        public IRankCalculator GetAll()
        {
            var recommendedProgrammers = _xmlLoader.Load()
                .Descendants("Programmer")
                .Select(programmer => programmer.Attribute("name").Value )
                .Select(programmer => new {
                    Programmer = programmer,
                    Recommendations = _xmlLoader.Load()
                        .Descendants("Programmer")
                        .Where(p => p.Attribute("name").Value == programmer)
                        .Descendants("Recommendations")
                        .Descendants("Recommendation")
                        .Select(recommendation => recommendation.Value)})
                .ToDictionary(tuple => tuple.Programmer, tuple => tuple.Recommendations);

            return _rankedProgrammersBuilder.BuildProgrammers(recommendedProgrammers);
        }
    }
}