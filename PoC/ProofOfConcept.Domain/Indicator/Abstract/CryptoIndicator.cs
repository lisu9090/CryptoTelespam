using System.Collections;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator.Abstract
{
    public abstract class CryptoIndicator<T> : CryptoIndicatorBase, IEnumerable<IndicatorValue<T>>
    {
        private List<IndicatorValue<T>> _values = new List<IndicatorValue<T>>();

        public IndicatorValue<T> this[int index]
        {
            get => _values[index];
            set => _values.Insert(index, value);
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