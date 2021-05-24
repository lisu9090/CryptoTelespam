using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.PuellZone
{
    internal class PuellHopeSelector : ZoneSelectorBase, IZoneSelector
    {
        public PuellHopeSelector() : base(Range.And(x => x >= 0.5, x => x < 1.5), ZoneId.Hope)
        {
        }
    }
}