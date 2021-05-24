using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.NuplZone
{
    internal class NuplCapitulationSelector : ZoneSelectorBase, IZoneSelector
    {
        public NuplCapitulationSelector() : base(Range.And(x => x >= double.MinValue, x => x < 0), ZoneId.Capitulation)
        {
        }
    }
}