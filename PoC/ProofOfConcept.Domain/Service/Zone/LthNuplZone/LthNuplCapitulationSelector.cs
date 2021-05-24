using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.LthNuplZone
{
    internal class LthNuplCapitulationSelector : ZoneSelectorBase, IZoneSelector
    {
        public LthNuplCapitulationSelector() : base(Range.And(x => x >= double.MinValue, x => x < 0), ZoneId.Capitulation)
        {
        }
    }
}