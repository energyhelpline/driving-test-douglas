using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class ProgrammerRank
    {
        private readonly List<IRankUpdateable> _programmers;

        public ProgrammerRank(List<IRankUpdateable> programmers)
        {
            _programmers = programmers;
        }

        public void Calculate()
        {
            do
            {
                foreach (var programmer in _programmers)
                {
                    programmer.UpdateRank();
                }
            } while (_programmers.Average(programmer => programmer.Rank) < 1);
        }
    }
}