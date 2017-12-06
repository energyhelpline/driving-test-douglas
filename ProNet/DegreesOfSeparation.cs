using System;
using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class DegreesOfSeparation
    {
        private readonly Association _association;

        public DegreesOfSeparation(Association association)
        {
            _association = association;
        }

        public int Calculate(Association associationTo)
        {
            if (_association == associationTo)
                return 0;

            var toProcess = new Queue<Tuple<int, Association>>();
            toProcess.Enqueue(new Tuple<int, Association>(1, _association));

            while (toProcess.Count > 0)
            {
                var programmerToProcess = toProcess.Dequeue();

                if (HasRecommended(programmerToProcess, associationTo))
                    return programmerToProcess.Item1;

                if (IsRecommendedBy(programmerToProcess, associationTo))
                    return programmerToProcess.Item1;

                AddRecommendationsTo(toProcess, programmerToProcess.Item1 + 1, programmerToProcess.Item2);

                AddRecommendedBysTo(toProcess, programmerToProcess.Item1 + 1, programmerToProcess.Item2);
            }

            throw new ProgrammersNotConnectedException();
        }

        public bool HasRecommended(Tuple<int, Association> recommending, Association recommendended)
        {
            var item2Recommendations = recommending.Item2.Recommendations();

            return item2Recommendations.Any(recommendation => recommendation == recommendended);
        }

        public bool IsRecommendedBy(Tuple<int, Association> recommendedBy, Association recommending)
        {
            return recommendedBy.Item2.RecommendedBys().Any(recommendation => recommendation == recommending);
        }

        public void AddRecommendationsTo(Queue<Tuple<int, Association>> queue, int degreeOfSeparation, Association processed)
        {
            foreach (var recommendation in processed.Recommendations())
            {
                if (processed != recommendation)
                    queue.Enqueue(new Tuple<int, Association>(degreeOfSeparation, recommendation));
            }
        }

        public void AddRecommendedBysTo(Queue<Tuple<int, Association>> queue, int degreeOfSeparation, Association processed)
        {
            foreach (var recommendedBy in processed.RecommendedBys())
            {
                if (processed != recommendedBy)
                    queue.Enqueue(new Tuple<int, Association>(degreeOfSeparation, recommendedBy));
            }
        }
    }
}