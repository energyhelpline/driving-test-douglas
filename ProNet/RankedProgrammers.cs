using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class RankedProgrammers : IEnumerable<IRankUpdateable>
    {
        public readonly IEnumerable<IRankUpdateable> _programmers;

        public RankedProgrammers(IEnumerable<IRankUpdateable> programmers)
        {
            _programmers = programmers;
        }

        public IEnumerator<IRankUpdateable> GetEnumerator()
        {
            return _programmers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public decimal AverageRank()
        {
            return _programmers.Average(programmer => programmer.Rank);
        }
    }
}