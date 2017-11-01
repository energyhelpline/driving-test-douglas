using System.Collections.Generic;

namespace ProNet
{
    public interface IRankUpdateable
    {
        void UpdateRank();
        decimal Rank { get; }
        string Name { get; }
        IEnumerable<string> Recommendations { get; }
    }
}