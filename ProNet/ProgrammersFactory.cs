using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class ProgrammersFactory : IProgrammersFactory
    {
        private readonly IProgrammerFactory _programmerFactory;

        public ProgrammersFactory(IProgrammerFactory programmerFactory)
        {
            _programmerFactory = programmerFactory;
        }

        public IProgrammers BuildProgrammers(IReadOnlyDictionary<string, IEnumerable<string>> rawProgrammers)
        {
            var listOfProgrammers = rawProgrammers
                .Select(programmer => _programmerFactory.BuildProgrammer(programmer.Key))
                .ToList();

            var programmers = new Programmers(listOfProgrammers);

            return AddRecommendations(programmers, rawProgrammers);
        }

        private IProgrammers AddRecommendations(IProgrammers programmers, IReadOnlyDictionary<string, IEnumerable<string>> recommenders)
        {
            foreach (var recommender in recommenders)
            {
                AddRecommendations(programmers, recommender.Key, recommenders[recommender.Key]);
            }

            return programmers;
        }

        private static void AddRecommendations(IProgrammers programmers, string recommender, IEnumerable<string> recommendations)
        {
            foreach (var recommendation in recommendations)
            {
                programmers.AddRecommendation(recommender, recommendation);
            }
        }
    }
}