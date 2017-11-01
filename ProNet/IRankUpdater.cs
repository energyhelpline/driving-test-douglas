namespace ProNet
{
    public interface IRankUpdater
    {
        void UpdateRanks();
        decimal AverageRank();
    }
}