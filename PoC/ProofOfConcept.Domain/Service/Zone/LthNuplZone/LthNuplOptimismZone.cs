using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.LthNuplZone
{
    internal class LthNuplOptimismZone : ZoneSelectorBase, IZoneSelector
    {
        public LthNuplOptimismZone() : base(Range.And(x => x >= 0.25, x => x < 0.5), ZoneId.Optimism)
        {
        }
    }
}