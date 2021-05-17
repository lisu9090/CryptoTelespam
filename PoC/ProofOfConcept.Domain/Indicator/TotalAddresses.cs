using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.IndicatorTmp
{
    public class TotalAddresses : CryptoIndicator<int>
    {
        public TotalAddresses(int assetId, IEnumerable<IndicatorValue<int>> values) : base(assetId, values)
        {
        }

        public TotalAddresses(int assetId) : base(assetId)
        {
        }
    }
}