using System.Collections.Generic;

namespace ProNet
{
    public interface IRecommendationAdder
    {
        Programmers AddRecommendations(IReadOnlyDictionary<string, IEnumerable<string>> programmers);
    }
}