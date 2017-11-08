namespace ProNet
{
    public interface IProgrammers : IRankedProgrammers
    {
        void AddRecommendation(string recommender, string recommendation);
    }
}