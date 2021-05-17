using ProofOfConcept.Domain.Indicator.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator
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