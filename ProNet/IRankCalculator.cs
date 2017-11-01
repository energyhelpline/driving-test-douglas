using System.Collections.Generic;

namespace ProNet
{
    public interface IRankCalculator : IEnumerable<IRankUpdateable>
    {
        void Calculate();
        decimal RankFor(string name);
        string[] RecommendationsFor(string name);
    }
}