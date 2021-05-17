using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.IndicatorTmp
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