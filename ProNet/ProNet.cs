using System;

namespace ProNet
{
    public class ProNet : IProNet
    {
        private readonly IProgrammersProvider _programmersProvider;

        public ProNet(IProgrammersProvider programmersProvider)
        {
            _programmersProvider = programmersProvider;
        }

        public string[] Skills(string programmer)
        {
            throw new System.NotImplementedException();
        }

        public string[] Recommendations(string programmer)
        {
            throw new System.NotImplementedException();
        }

        public double Rank(string programmer)
        {
            var rankedProgrammers = _programmersProvider.GetAll();

            rankedProgrammers.Calculate();

            return Convert.ToDouble(rankedProgrammers.RankFor(programmer));
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