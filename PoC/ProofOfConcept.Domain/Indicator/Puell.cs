using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.IndicatorTmp
{
    public class Puell : CryptoIndicator<float>
    {
        public Puell(int assetId, IEnumerable<IndicatorValue<float>> values) : base(assetId, values)
        {
        }

        public Puell(int assetId) : base(assetId)
        {
        }
    }
}