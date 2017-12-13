using System;
using System.Linq;

namespace ProNet
{
    public class ProNet : IProNet
    {
        private readonly IRankedProgrammers _programmers;

        public ProNet(IProgrammersStore programmersStore)
        {
            _programmers = programmersStore.GetAll();
            _programmers.Calculate();
        }

        public string[] Skills(string programmer)
        {
            return _programmers.Skills(programmer).ToArray();
        }

        public string[] Recommendations(string programmer)
        {
            return _programmers.RecommendationsFor(programmer).ToArray();
        }

        public double Rank(string programmer)
        {
            return Convert.ToDouble(_programmers.RankFor(programmer));
        }

        public int DegreesOfSeparation(string programmer1, string programmer2)
        {
            return _programmers.DegreesOfSeparation(programmer1, programmer2);
        }

        public double TeamStrength(string language, string[] team)
        {
            throw new System.NotImplementedException();
        }

        public string[] FindStrongestTeam(string language, int teamSize)
        {
            throw new System.NotImplementedException();
        }
    }
}