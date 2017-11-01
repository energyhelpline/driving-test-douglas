namespace ProNet
{
    public interface IRankedProgrammer
    {
        void RecommendedBy(IRankedProgrammer programmer);
        decimal ProgrammerRankShare { get; }
        string Name { get; }
    }
}