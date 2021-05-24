using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.PuellZone
{
    internal class PuellOptimismSelector : ZoneSelectorBase, IZoneSelector
    {
        public PuellOptimismSelector() : base(Range.And(x => x >= 1.5, x => x < 3.0), ZoneId.Optimism)
        {
        }
    }
}