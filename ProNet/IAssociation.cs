using System.Collections.Generic;

namespace ProNet
{
    public interface IAssociation
    {
        IEnumerable<IAssociation> Recommendations { get; }
        IEnumerable<IAssociation> RecommendedBys { get; }
        int DegreesOfSeparation(IAssociation name);
    }
}