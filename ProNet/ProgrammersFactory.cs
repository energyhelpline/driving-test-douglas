using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class ProgrammersFactory : IProgrammersFactory
    {
        private readonly IRecommendationAdder _recommendationAdder;
        private readonly IProgrammerFactory _programmerFactory;

        public ProgrammersFactory(IRecommendationAdder recommendationAdder, IProgrammerFactory programmerFactory)
        {
            _recommendationAdder = recommendationAdder;
            _programmerFactory = programmerFactory;
        }

        public IProgrammers BuildProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> rawProgrammer)
        {
            var listOfProgrammers = rawProgrammer
                .Select(programmer => _programmerFactory.BuildProgrammer(programmer))
                .ToList();

            var programmers = new Programmers(listOfProgrammers);

            _recommendationAdder.AddRecommendations(programmers, rawProgrammer);

            return programmers;
        }
    }
}