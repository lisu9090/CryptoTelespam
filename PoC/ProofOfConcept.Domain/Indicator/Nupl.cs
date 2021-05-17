using ProofOfConcept.Domain.Indicator.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator
{
    public class Nupl : CryptoIndicator<float>
    {
        public Nupl(int assetId, IEnumerable<IndicatorValue<float>> values) : base(assetId, values)
        {
        }

        public Nupl(int assetId) : base(assetId)
        {
        }
    }
}