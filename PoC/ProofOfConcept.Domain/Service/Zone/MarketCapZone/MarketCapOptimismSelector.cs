using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.MarketCapZone
{
    internal class MarketCapOptimismSelector : ZoneSelectorBase, IZoneSelector
    {
        public MarketCapOptimismSelector() : base(Range.And(x => x >= 0.0000001, x => x < 0.00000025), ZoneId.Optimism)
        {
        }
    }
}