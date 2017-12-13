using System;
using System.Collections.Generic;
using System.Linq;

namespace ProNet
{
    public class DegreesOfSeparation
    {
        public int Calculate(IAssociation programmerFrom, IAssociation programmer)
        {
            if (programmerFrom == programmer)
                return 0;

            var toProcess = new Queue<Tuple<int, IAssociation>>();
            toProcess.Enqueue(new Tuple<int, IAssociation>(1, programmerFrom));

            while (toProcess.Count > 0)
            {
                var programmerToProcess = toProcess.Dequeue();

                if (HasRecommended(programmerToProcess, programmer))
                    return programmerToProcess.Item1;

                if (IsRecommendedBy(programmerToProcess, programmer))
                    return programmerToProcess.Item1;

                AddRecommendationsTo(toProcess, programmerToProcess.Item1 + 1, programmerToProcess.Item2);

                AddRecommendedBysTo(toProcess, programmerToProcess.Item1 + 1, programmerToProcess.Item2);
            }

            throw new NotConnected();
        }

        public bool HasRecommended(Tuple<int, IAssociation> programmerToProcess, IAssociation programmer)
        {
            return programmerToProcess.Item2.Recommendations.Contains(programmer);
        }

        public bool IsRecommendedBy(Tuple<int, IAssociation> programmerToProcess, IAssociation programmer)
        {
            return programmerToProcess.Item2.RecommendedBys.Contains(programmer);
        }

        public void AddRecommendationsTo(Queue<Tuple<int, IAssociation>> queue, int degreeOfSeparation, IAssociation processed)
        {
            foreach (var recommendation in processed.Recommendations)
            {
                if (processed != recommendation)
                    queue.Enqueue(new Tuple<int, IAssociation>(degreeOfSeparation, recommendation));
            }
        }

        public void AddRecommendedBysTo(Queue<Tuple<int, IAssociation>> queue, int degreeOfSeparation, IAssociation processed)
        {
            foreach (var recommendedBy in processed.RecommendedBys)
            {
                if (processed != recommendedBy)
                    queue.Enqueue(new Tuple<int, IAssociation>(degreeOfSeparation, recommendedBy));
            }
        }
    }
}