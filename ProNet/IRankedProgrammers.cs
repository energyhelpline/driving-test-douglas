using System.Collections.Generic;

namespace ProNet
{
    public interface IRankedProgrammers
    {
        void Calculate();
        decimal RankFor(string name);
        IEnumerable<string> RecommendationsFor(string name);
    }
}