using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ProNet.Test.Unit
{
    [TestFixture]
    public class ProNet
    {
        [Test]
        public void Should_calculate_programmer_rank()
        {
            var programmer = new Programmer("Dave", "Bill");
            var programmerRank = programmer.Rank(new Dictionary<string, Tuple<decimal, int>>{{"Bill", new Tuple<decimal,int>(0m, 1)}, {"Dave", new Tuple<decimal, int>(0m, 1)}});
            Assert.That(programmerRank, Is.EqualTo(0.15m));
        }
    }

    public class Programmer
    {
        private readonly string _name;
        private readonly string _recommendations;

        public Programmer(string name, string recommendations)
        {
            _name = name;
            _recommendations = recommendations;
        }

        public decimal Rank(Dictionary<string, Tuple<decimal, int>> programmerRanks)
        {
            // (1 - d) + d(PR(T1)/C(T1)) + ... + d(PR(Tn)/C(Tn))
            return (1m - 0.85m) + (0.85m * (programmerRanks[_recommendations].Item1/programmerRanks[_recommendations].Item2));
        }
    }
}