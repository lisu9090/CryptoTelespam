using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.LthNuplZone
{
    internal class LthNuplHopeSelector : ZoneSelectorBase, IZoneSelector
    {
        public LthNuplHopeSelector() : base(Range.And(x => x >= 0.5, x => x < 0.75), ZoneId.Hope)
        {
        }
    }
}