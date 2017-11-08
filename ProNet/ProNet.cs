using System;
using System.Linq;

namespace ProNet
{
    public class ProNet : IProNet
    {
        private readonly IProgrammers _programmers;

        public ProNet(IProgrammersStore programmersStore)
        {
            _programmers = programmersStore.GetAll();
            _programmers.Calculate();
        }

        public string[] Skills(string programmer)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
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