namespace ProNet
{
    public class ProgrammersProvider : IProgrammersProvider
    {
        public IRankCalculator GetAll()
        {
            return new RankedProgrammers(new []{new DummyProgrammer
            {
                Rank = 2.63m,
                Name = "Nick"
            }, new DummyProgrammer { Rank = 0.3m }, new DummyProgrammer { Rank = 0.07m }});
        }
    }
}