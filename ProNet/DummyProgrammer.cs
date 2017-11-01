namespace ProNet
{
    public class DummyProgrammer : IRankUpdateable
    {
        public void UpdateRank()
        {
            // no op
        }

        public decimal Rank { get; set; }
        public string Name { get; set; }
    }
}