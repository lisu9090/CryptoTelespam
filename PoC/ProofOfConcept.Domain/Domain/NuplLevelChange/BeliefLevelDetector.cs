using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Domain.NuplLevelChange
{
    internal class BeliefLevelDetector : INuplLevelChangeDetector
    {
        private INuplLevelChangeDetector _detector;

        public BeliefLevelDetector(INuplLevelChangeDetector detector)
        {
            _detector = detector;
        }

        public string Detect(Nupl data)
        {
            throw new NotImplementedException();
        }
    }
}
