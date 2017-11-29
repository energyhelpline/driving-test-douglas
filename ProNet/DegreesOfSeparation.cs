using System;
using System.Collections.Generic;

namespace ProNet
{
    public class DegreesOfSeparation
    {
        private Programmer _programmer;

        public DegreesOfSeparation(Programmer programmer1)
        {
            _programmer = programmer1;
        }

        public int Calculate(IProgrammer programmer)
        {
            if (_programmer == programmer)
                return 0;

            var toProcess = new Queue<Tuple<int, IProgrammer>>();
            toProcess.Enqueue(new Tuple<int, IProgrammer>(1, _programmer));

            while (toProcess.Count > 0)
            {
                var programmerToProcess = toProcess.Dequeue();

                if (programmerToProcess.Item2.HasRecommended(programmer))
                    return programmerToProcess.Item1;

                if (programmerToProcess.Item2.IsRecommendedBy(programmer))
                    return programmerToProcess.Item1;

                programmerToProcess.Item2.AddRecommendationsTo(toProcess, programmerToProcess.Item1 + 1, programmerToProcess.Item2);

                programmerToProcess.Item2.AddRecommendedBysTo(toProcess, programmerToProcess.Item1 + 1, programmerToProcess.Item2);
            }

            throw new ProgrammersNotConnectedException();
        }

        public bool HasRecommended(IProgrammer programmer)
        {
            return _programmer._recommendations.Contains(programmer);
        }

        public bool IsRecommendedBy(IProgrammer programmer)
        {
            return _programmer._recommendedBy.Contains(programmer);
        }

        public void AddRecommendationsTo(Queue<Tuple<int, IProgrammer>> queue, int degreeOfSeparation, IProgrammer processed)
        {
            foreach (var recommendation in _programmer._recommendations)
            {
                if (processed != recommendation)
                    queue.Enqueue(new Tuple<int, IProgrammer>(degreeOfSeparation, recommendation));
            }
        }

        public void AddRecommendedBysTo(Queue<Tuple<int, IProgrammer>> queue, int degreeOfSeparation, IProgrammer processed)
        {
            foreach (var recommendedBy in _programmer._recommendedBy)
            {
                if (processed != recommendedBy)
                    queue.Enqueue(new Tuple<int, IProgrammer>(degreeOfSeparation, recommendedBy));
            }
        }
    }
}