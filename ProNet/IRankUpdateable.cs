namespace ProNet
{
    public interface IRankUpdateable
    {
        void UpdateRank();
        decimal Rank { get; }
    }
}