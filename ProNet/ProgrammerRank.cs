using System.Diagnostics.CodeAnalysis;

namespace ProNet
{
    public class ProgrammerRank
    {
        private readonly RankedProgrammers _programmers;

        public ProgrammerRank(RankedProgrammers programmers)
        {
            _programmers = programmers;
        }

        [SuppressMessage("CodeCraft.FxCop", "TT1012:FeatureEnvyRule")]
        public void Calculate()
        {
            do
            {
                _programmers.UpdateRanks();
            } while (_programmers.AverageRank() < 1);
        }
    }
}