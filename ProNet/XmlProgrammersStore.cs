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
            return _programmersFactory.BuildProgrammers(GetRecommendations(), GetSkills());
        }

        private IReadOnlyDictionary<string, IEnumerable<string>> GetRecommendations()
        {
            return GetProgrammerNames()
                .Select(name => new {
                    Programmer = name,
                    Recommendations = GetRecommendationsFor(name)
                })
                .ToDictionary(tuple => tuple.Programmer, tuple => tuple.Recommendations);
        }

        private IEnumerable<string> GetRecommendationsFor(string name)
        {
            return GetProgrammer(name)
                .Descendants("Recommendations")
                .Descendants("Recommendation")
                .Select(recommendation => recommendation.Value);
        }

        private IReadOnlyDictionary<string, IEnumerable<string>> GetSkills()
        {
            return GetProgrammerNames()
                .Select(name => new {Name = name, Skills = GetSkillsFor(name) })
                .ToDictionary(programmer => programmer.Name, programmer => programmer.Skills);
        }

        private IEnumerable<string> GetSkillsFor(string name)
        {
            return GetProgrammer(name)
                .Descendants("Skills")
                .Descendants("Skill")
                .Select(skill => skill.Value);
        }

        private IEnumerable<string> GetProgrammerNames()
        {
            return _xmlLoader.Load()
                .Descendants("Programmer")
                .Select(programmer => programmer.Attribute("name").Value );
        }

        private IEnumerable<XElement> GetProgrammer(string name)
        {
            return _xmlLoader.Load()
                .Descendants("Programmer")
                .Where(p => p.Attribute("name").Value == name);
        }
    }
}