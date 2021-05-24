using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.LthNuplZone
{
    internal class LthNuplOptimismSelector : ZoneSelectorBase, IZoneSelector
    {
        public LthNuplOptimismSelector() : base(Range.And(x => x >= 0.25, x => x < 0.5), ZoneId.Optimism)
        {
        }
    }
}