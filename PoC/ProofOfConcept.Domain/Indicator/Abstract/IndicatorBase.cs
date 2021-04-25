using ProofOfConcept.Domain.Entity;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator.Abstract
{
    public abstract class IndicatorBase
    {
        public abstract int Id { get; }
        public Asset Asset { get; set; }
    }
}