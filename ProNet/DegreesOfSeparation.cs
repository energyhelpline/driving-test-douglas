using System;
using System.Collections.Generic;

namespace ProNet
{
    public class DegreesOfSeparation
    {
        public int Calculate(IProgrammer programmerFrom, IProgrammer programmer)
        {
            if (programmerFrom == programmer)
                return 0;

            var toProcess = new Queue<Tuple<int, IProgrammer>>();
            toProcess.Enqueue(new Tuple<int, IProgrammer>(1, programmerFrom));

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

            throw new ProgrammersNotConnectedException();
        }

        public bool HasRecommended(Tuple<int, IProgrammer> programmerToProcess, IProgrammer programmer)
        {
            return programmerToProcess.Item2.Recommendations.Contains(programmer);
        }

        public bool IsRecommendedBy(Tuple<int, IProgrammer> programmerToProcess, IProgrammer programmer)
        {
            return programmerToProcess.Item2.RecommendedBys.Contains(programmer);
        }

        public void AddRecommendationsTo(Queue<Tuple<int, IProgrammer>> queue, int degreeOfSeparation, IProgrammer processed)
        {
            foreach (var recommendation in processed.Recommendations)
            {
                if (processed != recommendation)
                    queue.Enqueue(new Tuple<int, IProgrammer>(degreeOfSeparation, recommendation));
            }
        }

        public void AddRecommendedBysTo(Queue<Tuple<int, IProgrammer>> queue, int degreeOfSeparation, IProgrammer processed)
        {
            foreach (var recommendedBy in processed.RecommendedBys)
            {
                if (processed != recommendedBy)
                    queue.Enqueue(new Tuple<int, IProgrammer>(degreeOfSeparation, recommendedBy));
            }
        }
    }
}