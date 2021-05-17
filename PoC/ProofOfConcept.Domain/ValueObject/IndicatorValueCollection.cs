using ProofOfConcept.Domain.Entity;
using System.Collections;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.ValueObject
{
    public class IndicatorValueCollection<T> : IEnumerable<IndicatorValue<T>>
    {
        private IEnumerable<IndicatorValue<T>> _values;

        public int IndicatorId { get; private set; }

        public int AssetId { get; private set; }

        public Indicator Indicator { get; set; }

        public Asset Asset { get; set; }

        public IEnumerator<IndicatorValue<T>> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}