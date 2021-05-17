using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.IndicatorTmp
{
    public class MvrvZScore : CryptoIndicator<float>
    {
        public MvrvZScore(int assetId, IEnumerable<IndicatorValue<float>> values) : base(assetId, values)
        {
        }

        public MvrvZScore(int assetId) : base(assetId)
        {
        }
    }
}