using ProofOfConcept.Domain.Entity;
using ProofOfConcept.Domain.Enum;
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

        public IndicatorId IndicatorId { get; }

        public AssetId AssetId { get; }

        public Indicator Indicator
        {
            get => _indicator;
            set => _indicator = value.ConsistencyCheck((int)IndicatorId);
        }

        public Asset Asset
        {
            get => _asset;
            set => _asset = value.ConsistencyCheck((int)AssetId);
        }

        public IndicatorValueCollection(IEnumerable<IndicatorValue<T>> values, IndicatorId indicatorId, AssetId assetId)
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