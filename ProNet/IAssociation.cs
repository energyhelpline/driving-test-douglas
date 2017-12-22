namespace ProNet
{
    public interface IAssociation
    {
        int DegreesOfSeparation(IAssociation name);
        bool HasRecommended(IAssociation programmer);
        bool IsRecommendedBy(IAssociation programmer);
        void AddRecommendationsTo(DegreesOfSeparation degreesOfSeparation);
        void AddRecommendedBysTo(DegreesOfSeparation degreesOfSeparation);
    }
}