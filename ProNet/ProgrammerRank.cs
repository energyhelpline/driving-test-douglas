namespace ProNet
{
    public class ProgrammerRank
    {
        private readonly RankedProgrammers _programmers;

        public ProgrammerRank(RankedProgrammers programmers)
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
            } while (_programmers.AverageRank() < 1);
        }
    }
}