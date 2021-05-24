using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.PuellZone
{
    internal class PuellBeliefSelector : ZoneSelectorBase, IZoneSelector
    {
        public PuellBeliefSelector() : base(Range.And(x => x >= 3.0, x => x < 4.0), ZoneId.Beliefe)
        {
        }
    }
}