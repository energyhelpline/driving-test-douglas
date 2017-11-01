using System;

namespace ProNet
{
    public class ProNet : IProNet
    {
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
            var programmer1 = new DummyProgrammer();
            var programmer2 = new DummyProgrammer();
            var programmer3 = new DummyProgrammer();

            programmer1.Rank = 2.63m;
            programmer1.Name = "Nick";
            programmer2.Rank = 0.3m;
            programmer3.Rank = 0.07m;

            var rankedProgrammers = new RankedProgrammers(new []{programmer1, programmer2, programmer3});

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