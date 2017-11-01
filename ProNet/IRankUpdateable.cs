namespace ProNet
{
    public interface IRankUpdateable
    {
        void UpdateRank();
        decimal Rank { get; }
        string Name { get; }
    }
}