using System.Collections.Generic;

namespace ProNet
{
    public interface IRankedProgrammers
    {
        void Calculate();
        decimal RankFor(string name);
        IEnumerable<string> RecommendationsFor(string name);
        IEnumerable<string> Skills(string programmer);
        int DegreesOfSeparation(string programmer1, string programmer2);
    }
}