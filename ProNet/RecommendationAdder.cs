using System.Collections.Generic;

namespace ProNet
{
    public class RecommendationAdder : IRecommendationAdder
    {
        public IProgrammers AddRecommendations(IProgrammers programmers, IReadOnlyDictionary<string, IEnumerable<string>> recommenders)
        {
            foreach (var recommender in recommenders)
            {
                foreach (var recommendation in recommenders[recommender.Key])
                {
                    programmers.AddRecommendation(recommender.Key, recommendation);
                }
            }

            return programmers;
        }
    }
}