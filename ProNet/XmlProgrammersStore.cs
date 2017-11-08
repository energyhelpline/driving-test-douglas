using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ProNet
{
    public class XmlProgrammersStore : IProgrammersStore
    {
        private readonly IXmlLoader _xmlLoader;
        private readonly IRecommendationAdder _recommendationAdder;

        public XmlProgrammersStore(IXmlLoader xmlLoader, IRecommendationAdder recommendationAdder)
        {
            _xmlLoader = xmlLoader;
            _recommendationAdder = recommendationAdder;
        }

        public IProgrammers GetAll()
        {
            var programmerNames = GetProgrammerNames();

            var programmers = GetProgrammers(programmerNames);

            return _recommendationAdder.AddRecommendations(programmers);
        }

        private Dictionary<string, IEnumerable<string>> GetProgrammers(IEnumerable<string> programmerNames)
        {
            return programmerNames
                .Select(programmer => new {
                    Programmer = programmer,
                    Recommendations = GetRecommendations(programmer)})
                .ToDictionary(tuple => tuple.Programmer, tuple => tuple.Recommendations);
        }

        private IEnumerable<string> GetProgrammerNames()
        {
            return _xmlLoader.Load()
                .Descendants("Programmer")
                .Select(programmer => programmer.Attribute("name").Value );
        }

        private IEnumerable<string> GetRecommendations(string programmer)
        {
            return _xmlLoader.Load()
                .Descendants("Programmer")
                .Where(p => p.Attribute("name").Value == programmer)
                .Descendants("Recommendations")
                .Descendants("Recommendation")
                .Select(recommendation => recommendation.Value);
        }
    }
}