using System.Collections.Generic;

namespace ProNet
{
    public class RecommendationAdder : IRecommendationAdder
    {
        public IProgrammers AddRecommendations(IProgrammers programmers, IReadOnlyDictionary<string, IEnumerable<string>> recommenders)
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