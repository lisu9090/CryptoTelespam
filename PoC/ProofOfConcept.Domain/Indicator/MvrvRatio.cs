using ProofOfConcept.Domain.Indicator.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator
{
    public class MvrvRatio : CryptoIndicator<float>
    {
        public MvrvRatio(int assetId, IEnumerable<IndicatorValue<float>> values) : base(assetId, values)
        {
        }

        public MvrvRatio(int assetId) : base(assetId)
        {
        }
    }
}