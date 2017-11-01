using System.Diagnostics.CodeAnalysis;

namespace ProNet
{
    public class ProgrammerRank
    {
        private readonly IRankUpdater _programmers;

        public ProgrammerRank(IRankUpdater programmers)
        {
            _programmers = programmers;
        }

        [SuppressMessage("CodeCraft.FxCop", "TT1012:FeatureEnvyRule")]
        public void Calculate()
        {
            do
                _programmers.UpdateRanks();
            while (1 - _programmers.AverageRank() >= 0.000001m);
        }
    }
}