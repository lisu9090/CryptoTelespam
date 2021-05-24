using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.MarketCapZone
{
    internal class MarketCapBeliefSelector : ZoneSelectorBase, IZoneSelector
    {
        public MarketCapBeliefSelector() : base(Range.And(x => x >= 0.00000025, x => x < 0.0000004), ZoneId.Beliefe)
        {
        }
    }
}