using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.MarketCapZone
{
    internal class MarketCapHopeSelector : ZoneSelectorBase, IZoneSelector
    {
        public MarketCapHopeSelector() : base(Range.And(x => x >= 0.00000004, x => x < 0.0000001), ZoneId.Hope)
        {
        }
    }
}