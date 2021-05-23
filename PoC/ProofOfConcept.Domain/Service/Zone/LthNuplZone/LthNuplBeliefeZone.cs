using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.LthNuplZone
{
    internal class LthNuplBeliefeZone : ZoneSelectorBase, IZoneSelector
    {
        public LthNuplBeliefeZone() : base(Range.And(x => x >= 0, x => x < 0.25), ZoneId.Beliefe)
        {
        }
    }
}