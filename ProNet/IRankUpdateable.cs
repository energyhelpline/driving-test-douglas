namespace ProNet
{
    public interface IRankUpdateable
    {
        decimal ProgrammerRankShare { get; }
        void UpdateRank();
        decimal Rank { get; }
    }
}