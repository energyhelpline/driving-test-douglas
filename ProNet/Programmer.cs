using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class Programmer : IProgrammer
    {
        private readonly string _name;
        private readonly IEnumerable<string> _skills;
        private readonly DegreesOfSeparation _degreesOfSeparation;
        private readonly Association _association;
        private readonly RankedAssociation _rankedAssociation;
        private readonly NamedAssociation _namedAssociation;

        public Programmer(string name, IEnumerable<string> skills)
        {
            _name = name;
            _skills = skills;
            _association = new Association();
            _degreesOfSeparation = new DegreesOfSeparation(_association);
            _rankedAssociation = new RankedAssociation();
            _namedAssociation = new NamedAssociation(_name);
        }

        public decimal Rank => _rankedAssociation.Rank;
        public string Name => _name;
        public IEnumerable<string> RecommendedProgrammers => _namedAssociation.RecommendedProgrammers;
        public IEnumerable<string> Skills => _skills;
        public Association Association => _association;
        public RankedAssociation RankedAssociation => _rankedAssociation;
        public NamedAssociation NamedAssociation => _namedAssociation;

        public void UpdateRank()
        {
            _rankedAssociation.UpdateRank();
        }

        public void Recommends(IProgrammer programmer)
        {
            _association.Recommends(programmer.Association);
            _rankedAssociation.Recommends(programmer.RankedAssociation);
            _namedAssociation.Recommends(programmer.NamedAssociation);
        }

        public void RecommendedBy(IProgrammer programmer)
        {
            _association.RecommendedBy(programmer.Association);
        }

        public int DegreesOfSeparation(IProgrammer programmer)
        {
            return _degreesOfSeparation.Calculate(programmer.Association);
        }
    }

    public class NamedAssociation
    {
        private readonly string _name;
        private readonly ICollection<NamedAssociation> _recommendations;

        public NamedAssociation(string name)
        {
            _name = name;
            _recommendations = new List<NamedAssociation>();
        }

        public void Recommends(NamedAssociation association)
        {
            _recommendations.Add(association);
        }

        public string Name => _name;
        public IEnumerable<string> RecommendedProgrammers => _recommendations.Select(recommendation => recommendation.Name);
    }

    public class RankedAssociation
    {
        private readonly ICollection<RankedAssociation> _recommendations;
        private readonly ICollection<RankedAssociation> _recommendedBys;
        private decimal _rank;

        public RankedAssociation()
        {
            _recommendations = new List<RankedAssociation>();
            _recommendedBys = new List<RankedAssociation>();
            _rank = 0;
        }

        public decimal Rank => _rank;

        public decimal RecommendationsCount => _recommendations.Count;

        public void Recommends(RankedAssociation programmer)
        {
            _recommendations.Add(programmer);
            programmer.RecommendedBy(this);
        }

        public void RecommendedBy(RankedAssociation programmer)
        {
            _recommendedBys.Add(programmer);
        }

        public ICollection<RankedAssociation> RecommendedBys()
        {
            return _recommendedBys;
        }

        public void UpdateRank()
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            _rank = RecommendedBys()
                .Aggregate(1m - 0.85m, (current, association) => current + 0.85m * association.Rank / association.RecommendationsCount);
        }
    }

    public class Association
    {
        private readonly ICollection<Association> _recommendations;
        private readonly ICollection<Association> _recommendedBys;

        public Association()
        {
            _recommendations = new List<Association>();
            _recommendedBys = new List<Association>();
        }

        public void Recommends(Association programmer)
        {
            _recommendations.Add(programmer);
            programmer.RecommendedBy(this);
        }

        public void RecommendedBy(Association programmer)
        {
            _recommendedBys.Add(programmer);
        }

        public ICollection<Association> Recommendations()
        {
            return _recommendations;
        }

        public ICollection<Association> RecommendedBys()
        {
            return _recommendedBys;
        }
    }
}
