using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.IndicatorTmp
{
    public class LthNupl : CryptoIndicator<float>
    {
        public LthNupl(int assetId, IEnumerable<IndicatorValue<float>> values) : base(assetId, values)
        {
        }

        public LthNupl(int assetId) : base(assetId)
        {
        }
    }
}