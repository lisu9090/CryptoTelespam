using ProofOfConcept.Domain.Indicator.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator
{
    public class MarketCapThermocapRatio : CryptoIndicator<float>
    {
        public MarketCapThermocapRatio(int assetId, IEnumerable<IndicatorValue<float>> values) : base(assetId, values)
        {
        }

        public MarketCapThermocapRatio(int assetId) : base(assetId)
        {
        }
    }
}