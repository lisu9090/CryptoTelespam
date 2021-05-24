using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.MarketCapZone
{
    internal class MarketCapEuphoriaSelector : ZoneSelectorBase, IZoneSelector
    {
        public MarketCapEuphoriaSelector() : base(Range.And(x => x >= 0.0000004, x => x <= double.MaxValue), ZoneId.Euphoria)
        {
        }
    }
}