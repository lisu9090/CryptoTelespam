using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.IndicatorTmp
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