using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.LthNuplZone
{
    internal class LthNuplEuphoriaSelector : ZoneSelectorBase, IZoneSelector
    {
        public LthNuplEuphoriaSelector() : base(Range.And(x => x >= 0.75, x => x <= double.MaxValue), ZoneId.Euphoria)
        {
        }
    }
}