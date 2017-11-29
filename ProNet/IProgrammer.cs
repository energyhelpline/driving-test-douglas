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
        ICollection<IProgrammer> _Recommendations { get; }
        ICollection<IProgrammer> _RecommendedBy { get; }
        void Recommends(IProgrammer programmer);
        int DegreesOfSeparation(IProgrammer name);
        void AddRecommendationsTo(Queue<Tuple<int, IProgrammer>> queue, int degreeOfSeparation, IProgrammer processed);
        void AddRecommendedBysTo(Queue<Tuple<int, IProgrammer>> queue, int degreeOfSeparation, IProgrammer processed);
    }
}