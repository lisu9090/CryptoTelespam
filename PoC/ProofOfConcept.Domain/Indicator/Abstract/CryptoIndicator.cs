using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator.Abstract
{
    public abstract class CryptoIndicator<T> : CryptoIndicatorBase
    {
        public IEnumerable<IndicatorValue<T>> Values { get; set; }
    }
}