using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.LthNuplZone
{
    internal class LthNuplCapitulationZone : ZoneSelectorBase, IZoneSelector
    {
        public LthNuplCapitulationZone() : base(Range.And(x => x >= double.MinValue, x => x < 0), ZoneId.Capitulation)
        {
        }
    }
}