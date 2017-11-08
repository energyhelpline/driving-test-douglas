﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;

namespace ProNet
{
    [SuppressMessage("CodeCraft.FxCop", "TT1020:MaxCollaboratorsRule", Scope = "type", Target = "ProNet.XmlProgrammersStore")]
    public class XmlProgrammersStore : IProgrammersStore
    {
        private readonly IXmlLoader _xmlLoader;
        private readonly IProgrammersBuilder _programmersBuilder;

        public XmlProgrammersStore(IXmlLoader xmlLoader, IProgrammersBuilder programmersBuilder)
        {
            _xmlLoader = xmlLoader;
            _programmersBuilder = programmersBuilder;
        }

        public IRankCalculator GetAll()
        {
            var programmerNames = GetProgrammerNames();

            var programmers = GetProgrammers(programmerNames);

            return _programmersBuilder.BuildProgrammers(programmers);
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