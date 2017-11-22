using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ProNet
{
    public class XmlProgrammersStore : IProgrammersStore
    {
        private readonly IXmlLoader _xmlLoader;
        private readonly IProgrammersFactory _programmersFactory;

        public XmlProgrammersStore(IXmlLoader xmlLoader, IProgrammersFactory programmersFactory)
        {
            _xmlLoader = xmlLoader;
            _programmersFactory = programmersFactory;
        }

        public IProgrammers GetAll()
        {
            var programmerNames = GetProgrammerNames();

            var recommendations = GetProgrammers(programmerNames);

            var skills = GetSkills();

            return _programmersFactory.BuildProgrammers(recommendations, skills);
        }

        private Dictionary<string, IEnumerable<string>> GetSkills()
        {
            return GetProgrammerNames()
                .Select(name => new {Name = name, Skills = GetSkills(name) })
                .ToDictionary(programmer => programmer.Name, programmer => programmer.Skills);
        }

        private IEnumerable<string> GetSkills(string name)
        {
            return _xmlLoader.Load()
                .Descendants("Programmer")
                .Where(p => p.Attribute("name").Value == name)
                .Descendants("Skills")
                .Descendants("Skill")
                .Select(skill => skill.Value);
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