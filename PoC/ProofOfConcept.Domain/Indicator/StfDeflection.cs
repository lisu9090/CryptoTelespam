using ProofOfConcept.Domain.Indicator.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator
{
    public class StfDeflection : CryptoIndicator<float>
    {
        public StfDeflection(int assetId, IEnumerable<IndicatorValue<float>> values) : base(assetId, values)
        {
        }

        public StfDeflection(int assetId) : base(assetId)
        {
        }
    }
}