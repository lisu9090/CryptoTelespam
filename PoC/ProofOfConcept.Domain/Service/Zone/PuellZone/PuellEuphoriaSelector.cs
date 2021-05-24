using ProofOfConcept.Common;
using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;

namespace ProofOfConcept.Domain.Service.Zone.PuellZone
{
    internal class PuellEuphoriaSelector : ZoneSelectorBase, IZoneSelector
    {
        public PuellEuphoriaSelector() : base(Range.And(x => x >= 4.0f, x => x <= double.MaxValue), ZoneId.Euphoria)
        {
        }
    }
}