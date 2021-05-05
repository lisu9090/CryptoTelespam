using System.Collections;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator.Abstract
{
    public abstract class CryptoIndicator<T> : CryptoIndicatorBase, IEnumerable<IndicatorValue<T>>
    {
        private IEnumerable<IndicatorValue<T>> _values;

        public CryptoIndicator(int assetId, IEnumerable<IndicatorValue<T>> values) : base(assetId)
        {
            _values = values;
        }

        public CryptoIndicator(int assetId) : base(assetId)
        {
            _values = new List<IndicatorValue<T>>();
        }

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