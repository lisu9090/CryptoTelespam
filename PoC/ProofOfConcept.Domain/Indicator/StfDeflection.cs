using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.IndicatorTmp
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