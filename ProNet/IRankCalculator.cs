using System.Collections.Generic;

namespace ProNet
{
    public interface IRankCalculator : IEnumerable<IRankedProgrammer>
    {
        void Calculate();
        decimal RankFor(string name);
        IEnumerable<string> RecommendationsFor(string name);
    }
}