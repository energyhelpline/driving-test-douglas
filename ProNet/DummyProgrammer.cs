using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class DummyProgrammer : IRankUpdateable
    {
        private readonly ICollection<IRankUpdateable> _recommendations;

        public DummyProgrammer()
        {
            _recommendations = new List<IRankUpdateable>();
        }

        public void Recommends(DummyProgrammer programmer)
        {
            _recommendations.Add(programmer);
        }

        public void UpdateRank()
        {
            // no op
        }

        public decimal Rank { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Recommendations => _recommendations.Select(programmer => programmer.Name);
    }
}