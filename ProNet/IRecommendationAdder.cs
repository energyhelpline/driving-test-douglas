using System.Collections.Generic;

namespace ProNet
{
    public interface IRecommendationAdder
    {
        IRankCalculator AddRecommendations(IReadOnlyDictionary<string, IEnumerable<string>> programmers);
    }
}