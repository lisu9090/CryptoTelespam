using ProofOfConcept.Domain.Indicator.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Indicator
{
    public class NewAddresses : CryptoIndicator<int>
    {
        public NewAddresses(int assetId, IEnumerable<IndicatorValue<int>> values) : base(assetId, values)
        {
        }

        public NewAddresses(int assetId) : base(assetId)
        {
        }
    }
}