using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.PuellZone
{
    internal class PuellCapitulationSelector : ZoneSelectorBase, IZoneSelector
    {
        public PuellCapitulationSelector() : base(Range.And(x => x >= double.MinValue, x => x < 0.5), ZoneId.Capitulation)
        {
        }
    }
}