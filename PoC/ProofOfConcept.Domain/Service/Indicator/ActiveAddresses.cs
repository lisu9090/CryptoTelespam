using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.IndicatorTmp
{
    public class ActiveAddresses : CryptoIndicator<int>
    {
        public ActiveAddresses(int assetId, IEnumerable<IndicatorValue<int>> values) : base(assetId, values)
        {
        }

        public ActiveAddresses(int assetId) : base(assetId)
        {
        }
    }
}