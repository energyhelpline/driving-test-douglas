using System.Collections.Generic;

namespace ProNet
{
    public interface IRecommendationAdder
    {
        IProgrammers AddRecommendations(IReadOnlyDictionary<string, IEnumerable<string>> programmers);
    }
}