using System;
using System.Collections.Generic;

namespace ProNet
{
    public interface IProgrammer
    {
        void RecommendedBy(IProgrammer programmer);
        decimal ProgrammerRankShare { get; }
        string Name { get; }
        void UpdateRank();
        decimal Rank { get; }
        IEnumerable<string> Recommendations { get; }
        IEnumerable<string> Skills { get; }
        void Recommends(IProgrammer programmer);
        int DegreesOfSeparation(IProgrammer name);
        bool HasRecommended(IProgrammer programmer);
        bool IsRecommendedBy(IProgrammer programmer);
        void AddRecommendationsTo(Queue<Tuple<int, IProgrammer>> queue, int degreeOfSeparation, List<IProgrammer> processed);
        void AddRecommendedBysTo(Queue<Tuple<int, IProgrammer>> queue, int degreeOfSeparation, List<IProgrammer> processed);
    }
}