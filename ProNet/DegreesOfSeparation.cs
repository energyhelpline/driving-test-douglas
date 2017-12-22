using System;
using System.Collections.Generic;

namespace ProNet
{
    public class DegreesOfSeparation
    {
        private Queue<Tuple<int, IAssociation>> _toProcess;
        private int _degreeOfSeparation;
        private IAssociation _associationProcessed;

        public int Calculate(IAssociation programmerFrom, IAssociation programmer)
        {
            if (programmerFrom == programmer)
                return 0;

            var toProcess = new Queue<Tuple<int, IAssociation>>();
            _toProcess = toProcess;
            _toProcess.Enqueue(new Tuple<int, IAssociation>(1, programmerFrom));

            while (_toProcess.Count > 0)
            {
                var programmerToProcess = _toProcess.Dequeue();

                if (HasRecommended(programmerToProcess.Item2, programmer))
                    return programmerToProcess.Item1;

                if (IsRecommendedBy(programmerToProcess.Item2, programmer))
                    return programmerToProcess.Item1;

                _degreeOfSeparation = programmerToProcess.Item1 + 1;
                _associationProcessed = programmerToProcess.Item2;

                AddRecommendationsTo(_associationProcessed);

                AddRecommendedBysTo(_associationProcessed);
            }

            throw new NotConnected();
        }

        public bool HasRecommended(IAssociation associationToProcess, IAssociation programmer)
        {
            return associationToProcess.HasRecommended(programmer);
        }

        public bool IsRecommendedBy(IAssociation associationToProcess, IAssociation programmer)
        {
            return associationToProcess.IsRecommendedBy(programmer);
        }

        public void AddRecommendationsTo(IAssociation processed)
        {
            processed.AddRecommendationsTo(this);
        }

        public void AddRecommendedBysTo(IAssociation processed)
        {
            processed.AddRecommendedBysTo(this);
        }

        public void AddToQueue(IEnumerable<IAssociation> recommendations)
        {
            foreach (var recommendation in recommendations)
            {
                if (_associationProcessed != recommendation)
                    _toProcess.Enqueue(new Tuple<int, IAssociation>(_degreeOfSeparation, recommendation));
            }
        }
    }
}