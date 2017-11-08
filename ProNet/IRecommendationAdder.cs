using System.Collections.Generic;

namespace ProNet
{
    public interface IRecommendationAdder
    {
        IProgrammers AddRecommendations(IProgrammers programmers, IReadOnlyDictionary<string, IEnumerable<string>> recommenders);
    }
}