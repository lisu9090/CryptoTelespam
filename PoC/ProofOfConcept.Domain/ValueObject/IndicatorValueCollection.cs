using ProofOfConcept.Domain.Entity;
using ProofOfConcept.Domain.Extension;
using System.Collections;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.ValueObject
{
    public class IndicatorValueCollection<T> : IEnumerable<IndicatorValue<T>>
    {
        private IEnumerable<IndicatorValue<T>> _values;
        private Indicator _indicator;
        private Asset _asset;

        public int IndicatorId { get; }

        public int AssetId { get; }

        public Indicator Indicator
        {
            get => _indicator;
            set => _indicator = value.ConsistencyCheck(IndicatorId);
        }

        public Asset Asset
        {
            get => _asset;
            set => _asset = value.ConsistencyCheck(AssetId);
        }

        public IndicatorValueCollection(IEnumerable<IndicatorValue<T>> values, int indicatorId, int assetId)
        {
            _values = values;
            IndicatorId = indicatorId;
            AssetId = assetId;
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