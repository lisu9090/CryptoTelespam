using ProofOfConcept.Domain.Entity;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator.Abstract
{
    public abstract class CryptocurrencyIndicator<T>
    {
        public Asset Asset { get; set; }

        public IEnumerable<IndicatorValue<T>> Values { get; set; }
    }
}