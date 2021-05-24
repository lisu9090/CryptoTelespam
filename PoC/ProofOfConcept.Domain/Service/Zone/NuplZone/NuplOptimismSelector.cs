using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.NuplZone
{
    internal class NuplOptimismSelector : ZoneSelectorBase, IZoneSelector
    {
        public NuplOptimismSelector() : base(Range.And(x => x >= 0.25, x => x < 0.5), ZoneId.Optimism)
        {
        }
    }
}