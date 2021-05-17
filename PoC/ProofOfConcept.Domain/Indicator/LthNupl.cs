using ProofOfConcept.Domain.Indicator.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator
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