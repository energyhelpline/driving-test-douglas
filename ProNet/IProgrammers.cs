using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammers
    {
        void Calculate();
        decimal RankFor(string name);
        IEnumerable<string> RecommendationsFor(string name);
    }
}